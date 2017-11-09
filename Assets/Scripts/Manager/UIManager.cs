using UnityEngine;
using System.Text;
using System.Collections.Generic;

public enum POPUP_TYPE { PAGE = 0, STACK, POPUP, FRONT }

public class UIManager : MonoBehaviour
{
    private static UIManager _instance = null;
    public static UIManager i
    {
        get
        {
            if (_instance == null)
            {

                var intance = FindObjectOfType<UIManager>();

                if (intance != null)
                {
                    _instance = intance;

                    return _instance;
                }

                _instance = Instantiate<UIManager>(Resources.Load<UIManager>("Prefabs/UI/UIManager"));
            }

            return _instance;
        }
    }

    private Transform _worldTrans;
    private Transform _pageTrans;
    private Transform _stackTrans;
    private Transform _popupTrans;
    private Transform _frontTrans;


    // 내가 string을 쓰는데 왜? const를 붙일까? 
    private const string WorldUI = "WorldUI";
    private const string PageUI = "PAGE";
    private const string StackUI = "STACK";
    private const string PopupUI = "POPUP";
    private const string FrontUI = "FRONT";
    private const string UIPath = "Prefabs/UI/";
    private const string ButtonPath = "Prefabs/UI/Button/";
    private const string SLASH = "/";

    private StringBuilder _textbulider = new StringBuilder(256);
    private List<UIPopupBase> _popupList = new List<UIPopupBase>();
    private List<UIPopupBase> _stackList = new List<UIPopupBase>();

    private UIPopupBase _pagePop = null;

    [HideInInspector]
    public Camera UICamera;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        FindSpecificTransform();
        UICamera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            RemoveTopUIObject();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            CreatePopup<PageMain>(POPUP_TYPE.PAGE);
        }
    }

    private void FindSpecificTransform()
    {
        _worldTrans = transform.Find(WorldUI);
        _pageTrans = transform.Find(PageUI);
        _stackTrans = transform.Find(StackUI);
        _popupTrans = transform.Find(PopupUI);
        _frontTrans = transform.Find(FrontUI);
    }

    // 어떤 팝업이던지 이제 이렇게 만들겠다라는 함수  
    public T CreatePopup<T>(POPUP_TYPE poptype) where T : UIPopupBase
    {
        _textbulider.Length = 0;
        _textbulider.Append(UIPath);
        _textbulider.Append(poptype.ToString());
        _textbulider.Append(SLASH);
        _textbulider.Append(typeof(T).ToString());

        GameObject pop = Resources.Load(_textbulider.ToString()) as GameObject;

        GameObject popup = Instantiate(pop);

        var returnValue = popup.GetComponent<T>();

        returnValue.TYPE = poptype;

        switch (poptype)
        {
            case POPUP_TYPE.PAGE:
                _pagePop = returnValue;
                popup.transform.SetParent(_pageTrans, false);
                break;
            case POPUP_TYPE.STACK:
                _stackList.Add(returnValue);
                popup.transform.SetParent(_stackTrans, false);
                break;
            case POPUP_TYPE.POPUP:
                popup.transform.SetParent(_popupTrans, false);
                _popupList.Add(returnValue);
                break;
            case POPUP_TYPE.FRONT:
                popup.transform.SetParent(_frontTrans, false);
                _popupList.Add(returnValue);
                break;
        }

        return returnValue;
    }

    public T GetPageUIObject<T>() where T : UIPopupBase
    {
        return _pagePop.GetComponent<T>();
    }

    public T GetStackUIObject<T>() where T : UIPopupBase
    {
        T obj = _stackList.Find((c) => c is T) as T;

        if (obj == null)
        {
            return null;
        }

        return obj.GetComponent<T>();
    }

    public T GetPopupUIObject<T>() where T : UIPopupBase
    {
        T obj = _popupList.Find((c) => c is T) as T;

        if (obj == null)
        {
            return null;
        }

        return obj.GetComponent<T>();
    }

    public void RemovePageUIObject()
    {
        Destroy(_pagePop.gameObject);
    }

    public void RemoveStackUIObject<T>() where T : UIPopupBase
    {
        T obj = _stackList.Find((c) => c is T) as T;

        if (obj == null)
            return;

        _stackList.Remove(obj);
        Destroy(obj.gameObject);
    }

    public void RemovePopupUIObject<T>() where T : UIPopupBase
    {
        T obj = _popupList.Find((c) => c is T) as T;

        if (obj == null)
            return;

        _popupList.Remove(obj);
        Destroy(obj.gameObject);
    }

    public void RemoveTopPopupUIObject()
    {
        if (_popupList.Count > 0)
        {
            var lastPop = _popupList.FindLast((c) => c);
            _popupList.Remove(lastPop);
            lastPop.RemovedUIObject();


            var pop = _popupList.FindLast((c) => c);
            if (pop != null) pop.ResetUIUpdata();
        }
    }

    public void RemoveTopStackUIObject()
    {

        if (_stackList.Count > 0)
        {
            var lastPop = _stackList.FindLast((c) => c);
            _stackList.Remove(lastPop);
            lastPop.RemovedUIObject();

            var pop = _stackList.FindLast((c) => c);
            if(pop !=null) pop.ResetUIUpdata();
        }
    }

    public void RemoveTopUIObject()
    {

        if (_popupList.Count > 0)
        {
            RemoveTopPopupUIObject();
            return;
        }

        RemoveTopStackUIObject();
    }


}
