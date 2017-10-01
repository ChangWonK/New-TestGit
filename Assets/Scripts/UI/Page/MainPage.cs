using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using uTools;




public class MainPage : UIPopupBase
{
    private Text _title;
    private Text _subTitle;
    private TweenPosition[] _tweens;

    private float _stopDefaultPosX = 125;

    

    void Awake()
    {
        //_title = GetText("Text_Title"); ;
        //_subTitle = GetText("Text_SubTitle"); ;

        //_title.text = "Real";
        //_subTitle.text = "SubReal";

        //var temp = transform.Find("Dummy2");

        ////var temppp = GetText(temp, "Text_four");
        //var temppp = GetText("Dummy2", "Text_four");

        //Debug.Log(temppp);        

        _tweens = GetComponentsInChildren<TweenPosition>(true);
    }

    void Start()
    {
        Transform buttons = transform.Find("Buttons");

        GetButton(buttons, "Btn_LoadScene").onClick.AddListener(() => GameManager.i.ChangeScene
            (SCENE_NAME.STAGE_SCENE, GameManager.i.MainSceneExitWaiting, GameManager.i.StageScenePrepareWaiting));

        GetButton(buttons, "Btn_HaveTower").onClick.AddListener(() => UIManager.i.CreatePopup<HaveTower>(POPUP_TYPE.STACK));
        // GetButton(buttons, "Btn_TowerShop").onClick.AddListener(() => UIManager.i.CreatePopup<TowerShopSecond>(POPUP_TYPE.STACK));

        //for Test
        ButtonTweenPlay(0);
    }


    public void ButtonTweenPlay(int index)
    {

        if (index >= _tweens.Length)
        {
            Debug.Log("트윈 애니메이션 끝");
            return;
        }
        
        _tweens[index].to = new Vector3(_stopDefaultPosX , _tweens[index].transform.position.y , 0);
        _tweens[index].style = Tweener.Style.Once;
        _tweens[index].method = EaseType.easeOutBounce;
        _tweens[index].delay = 0;
        _tweens[index].duration = 1.0f;        

        UnityEvent finishedEvent = new UnityEvent();        

        finishedEvent.AddListener( () => ButtonTweenPlay(index));

        _tweens[index].onFinished = finishedEvent;

        _tweens[index].PlayForward();

        index++;

    }



}
