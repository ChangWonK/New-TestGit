using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StackUpgradePanel : UIPopupBase
{
    private List<Unit> _showItemList = new List<Unit>();

    private ItemContent _upgradeItemContent;
    private ItemContent _consumableItemContent;

    private InfinityScrollView _scrollView;
    private Item _upgradeItem = null;
    private Item _consumableItem = null;

    private Text _probabilityTxt;
    private Text _costTxt;
    private Button _combinationBtn;
    private Button _realeaseBtn;


    private int _probabilityNum = 100;


    [HideInInspector]
    public long GetUpgradeItemUID;


    void Awake()
    {
        _scrollView = GetComponentInChildren<InfinityScrollView>();
        _upgradeItemContent = transform.Find("Contents").GetChild(0).GetComponent<ItemContent>();
        _consumableItemContent = transform.Find("Contents").GetChild(1).GetComponent<ItemContent>();

        _combinationBtn = RegistButtonOnClickEvent("Btn_Combination");
        _realeaseBtn = RegistButtonOnClickEvent("Btn_Realease");

    }


    void Start()
    {
        _combinationBtn.interactable = false;
        _realeaseBtn.interactable = false;
        _probabilityTxt = GetText("Txt_Probability");
        _costTxt = GetText("Txt_Cost");
        _upgradeItem = UserInformation.i.Inventory.FindItem(GetUpgradeItemUID);

        InitContent();
        CreateContent();
        SetContentInfo();
    }

    private void InitContent()
    {
        _upgradeItemContent.SetUIData(_upgradeItem.LocalIndex);
        _consumableItemContent.SetUIData(0);
    }

    private void CreateContent()
    {
        _scrollView.CreateContent(ContentIndex.ITEM , ContentClickEvent);
    }

    private void ContentClickEvent(int itemIndex, long itemUID)
    {
        UpdateData(itemUID);
    }


    private void SetContentInfo()
    {
        _scrollView.SetScrollView<ItemContent>(GetKindItemList());
    }

    private List<Unit> GetKindItemList()
    {
        _showItemList = UserInformation.i.Inventory.GetKindItemList(_upgradeItem.Kind);
        _showItemList.Remove(_upgradeItem);
        if(_consumableItem !=null) _showItemList.Remove(_consumableItem);
        return _showItemList;
    }

    private void CombinationButton()
    {
        UIManager.i.CreatePopup<PopupItemRelatedPanel>(POPUP_TYPE.POPUP).PopKind = PopupKind.UpgradePop;
    }
    public void Combination()
    {
        _upgradeItem = UnitManager.i.ItemCombination(_upgradeItem, _consumableItem, 100);
        InitContent();
        SetContentInfo();
        ButtonUpdate(false);
    }
 

    private UIPopupBase PopupItemRelatedPanel(POPUP_TYPE arg1)
    {
        throw new NotImplementedException();
    }

    private void RealeaseButton()
    {
        ButtonUpdate(false);
        _consumableItemContent.SetUIData(0);
        _consumableItem = null;
        SetContentInfo();
    }

    private void Probability()
    {
        //int compareRank = _upgradeItem.intRank + _consumableItem.intRank;
        //compareRank += 10 - _upgradeItem.intRank

        //int compareLevel = _upgradeItem.Level + _consumableItem.Level;
        //compareLevel += 10 - _upgradeItem.Level;
        //compareLevel += _consumableItem.Level;

        //compareRank = compareRank * 10;
        //compareLevel = compareLevel * 2;

        //_probabilityNum = compareRank + compareLevel;

        //int compareNum = _upgradeItem.LocalIndex - index;

                                        //if (compareNum <= 0) compareNum = 10;

                                        //if (_upgradeItem.Level <= 3)
                                        //{
                                        //    _probabilityNum = 80;
                                        //}
                                        //if (_upgradeItem.Level >= 4 & _upgradeItem.Level <= 6)
                                        //{
                                        //    _probabilityNum = 50;
                                        //}
                                        //if (_upgradeItem.Level >= 7)
                                        //{
                                        //    _probabilityNum = 30;
                                        //}
                                        //_probabilityNum = _probabilityNum + (compareNum * 2);

    }

    public override void RemovedUIObject()
    {
        var pop = UIManager.i.GetStackUIObject<StackItemManagement>();

        pop.GetIndex = _upgradeItem.LocalIndex;
        pop.GetUID = _upgradeItem.UID;

        UIManager.i.GetStackUIObject<StackUserEquipment>().ResetUIUpdata();

        base.RemovedUIObject();
    }

    private void ButtonUpdate(bool isActive)
    {
        if(_upgradeItem.Level == 10)
        {
            _realeaseBtn.interactable = false;
            _combinationBtn.interactable = true;
            return;
        }

        _realeaseBtn.interactable = isActive;
        _combinationBtn.interactable = isActive;
    }

    public void UpdateData(long uid)
    {
        ButtonUpdate(true);
        _consumableItem = _showItemList.Find((c) => c.UID == uid) as Item;
        _consumableItemContent.SetUIData(_consumableItem.LocalIndex, _consumableItem.UID);
        SetContentInfo();


        _probabilityTxt.text = "조합 확률 : " + _probabilityNum + "%";
        _costTxt.text = "조합 가격 : " + _upgradeItem.Cost;
    }

    protected override void OnButtonClick(string name)
    {
        if (name == "Btn_Combination")
        {
            CombinationButton();
        }
        if (name == "Btn_Realease")
        {
            RealeaseButton();
        }
    }

}
