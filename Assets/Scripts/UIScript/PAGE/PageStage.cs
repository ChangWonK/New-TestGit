using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageStage : UIPopupBase
{
    private PageScrollView _scrollView;

    void Awake()
    {
        _scrollView = GetComponentInChildren<PageScrollView>();
    }

    void Start()
    {
        _scrollView.Init(1150, 3, ContentClickEvent);
    }

    private void ContentClickEvent(GameMode mode, int stageLevel)
    {
       var pop = UIManager.i.CreatePopup<StackMapSelect>(POPUP_TYPE.STACK);
        pop.Init(mode, stageLevel);
    }

}
