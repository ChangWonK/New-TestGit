using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StackItemShop : UIPopupBase
{
    private ContentScrollView _scrollView;
    private TabButton _tabButton;

    void Awake()
    {
        _tabButton = GetComponentInChildren<TabButton>();
        _scrollView = GetComponentInChildren<ContentScrollView>();
    }

    void Start()
    {
        _scrollView.Init<ItemContent>(ScrollViewAxis.VERTICAL, ScrollContentKind.ITEM);

        _tabButton.AddListener(0, () => SetContentInfo(1, 3));
        _tabButton.AddListener(1, () => SetContentInfo(101, 3));
        _tabButton.AddListener(2, () => SetContentInfo(201, 3));
        _tabButton.AddListener(3, () => SetContentInfo(301, 3));
        _tabButton.AddListener(4, () => SetContentInfo(401, 3));

        _tabButton.Initialize(0);
    }

    private void SetContentInfo(int kindIndex, int dataCount)
    {
        int lineCount = 4;
        _scrollView.SetScrollView(kindIndex, dataCount, lineCount, ContentClickEvent);
    }

    private void ContentClickEvent(int itemIndex, long itemUID=0)
    {
        var pop = UIManager.i.CreatePopup<StackItemManagement>(POPUP_TYPE.STACK);
        pop.Init<StackItemShop>(itemIndex);
    }
}
