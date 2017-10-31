using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using uTools;


public class MainPage : UIPopupBase
{
    public ShowUserInformation ShowUserInfo;
    private TweenPosition[] _tweens;
    private float _stopDefaultPosX = 125;

    void Awake()
    {
        _tweens = GetComponentsInChildren<TweenPosition>();
        ShowUserInfo = GetComponentInChildren<ShowUserInformation>();
    }

    void Start()
    {
        RegistAllButtonOnClickEvent();
        //Transform buttons = transform.Find("Buttons");

        //GetButton(buttons, "Btn_LoadScene").onClick.AddListener(() => GameManager.i.ChangeScene
        //    (SCENE_NAME.STAGE_SCENE, GameManager.i.MainSceneExitWaiting, GameManager.i.StageScenePrepareWaiting));

        //GetButton(buttons, "Btn_UserEquipment").onClick.AddListener(() => UIManager.i.CreatePopup<UserEquipment>(POPUP_TYPE.STACK));
        //GetButton(buttons, "Btn_ItemShop").onClick.AddListener(() => UIManager.i.CreatePopup<ItemShop>(POPUP_TYPE.STACK));
        //GetButton(buttons, "Btn_TowerInformationList").onClick.AddListener(() => UIManager.i.CreatePopup<TowerInformationList>(POPUP_TYPE.STACK));

        ButtonTweenPlay(0);
    }


    public void ButtonTweenPlay(int index)
    {
        if (index >= _tweens.Length)
        {
            for (int i = 0; i < index; i++)
            {
                _tweens[i].GetComponent<Button>().interactable = true;

            }
            return;
        }

        _tweens[index].to = new Vector3(_stopDefaultPosX, _tweens[index].transform.localPosition.y, 0);
        _tweens[index].style = Tweener.Style.Once;
        _tweens[index].method = EaseType.easeOutBounce;
        _tweens[index].delay = 0;
        _tweens[index].duration = 0.5f;


        UnityEvent finishedEvent = new UnityEvent();

        finishedEvent.AddListener(() => ButtonTweenPlay(index));

        _tweens[index].onFinished = finishedEvent;

        _tweens[index].PlayForward();

        index++;

    }

    private void LoadScene()
    {
        GameManager.i.ChangeScene
            (SCENE_NAME.STAGE_SCENE, GameManager.i.MainSceneExitWaiting, GameManager.i.StageScenePrepareWaiting);
    }

    private void CreateUIPopup<T>() where T : UIPopupBase
    {
        UIManager.i.CreatePopup<T>(POPUP_TYPE.STACK);
    }

    protected override void OnButtonClick(string name)
    {
        if (name == "Btn_LoadScene")
        {
            LoadScene();
        }
        if (name == "Btn_ItemShop")
        {
            CreateUIPopup<StackItemShop>();
        }
        if (name == "Btn_UserEquipment")
        {
            CreateUIPopup<StackUserEquipment>();
        }
        if (name == "Btn_TowerInformationList")
        {
            CreateUIPopup<StackTowerList>();
        }

    }



}
