using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using uTools;


public class PageMain : UIPopupBase
{
    private TweenPosition[] _tweens;
    private float _stopDefaultPosX = 70;
    private Text _moneyTxt;

    void Awake()
    {
        Transform trans = transform.Find("Text");
        _moneyTxt = GetText(trans, "Txt_Money");
        _tweens = GetComponentsInChildren<TweenPosition>();
    }

    void Start()
    {
        RegistAllButtonOnClickEvent();
        ButtonTweenPlay(0);
        ResetUIUpdata();
    }

    public override void ResetUIUpdata()
    {
        _moneyTxt.text = UserInformation.i.Inventory.Money.ToString();
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
