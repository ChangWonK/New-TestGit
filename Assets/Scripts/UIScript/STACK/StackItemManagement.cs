﻿using UnityEngine;
using UnityEngine.UI;

public class StackItemManagement : UIPopupBase
{
    [HideInInspector]
    public long GetUID;
    [HideInInspector]
    public int GetIndex;
    private ItemInformation _itemInfo;

    private Button _buyBtn;
    private Button _upgradeBtn;
    private Button _sellBtn;
    private Button _moutingBtn;
    private Button _realeaseBtn;

    void Awake()
    {
        _itemInfo = GetComponentInChildren<ItemInformation>();

        _buyBtn = RegistButtonOnClickEvent("Btn_Buy");
        _upgradeBtn = RegistButtonOnClickEvent("Btn_Upgrade");
        _sellBtn = RegistButtonOnClickEvent("Btn_Sell");
        _moutingBtn = RegistButtonOnClickEvent("Btn_Mounting");
        _realeaseBtn = RegistButtonOnClickEvent("Btn_Realease");

    }

    public void Init<T>(int index, long uid = 0) where T : UIPopupBase
    {
        GetIndex = index;
        GetUID = uid;

        ResetUIUpdata();

        if (typeof(T).ToString() == "StackItemShop")
        {
            _upgradeBtn.gameObject.SetActive(false);
            _sellBtn.gameObject.SetActive(false);
            _moutingBtn.gameObject.SetActive(false);
            _realeaseBtn.gameObject.SetActive(false);
        }

        if (typeof(T).ToString() == "StackUserEquipment")
        {
            _buyBtn.gameObject.SetActive(false);
            ButtonUpdate();
        }
    }

    private void ButtonUpdate()
    {
        if (GetUID <= 0)
            return;

        if (UserInformation.i.Inventory.GetItem(GetUID).Level == 10)
        {
            _upgradeBtn.interactable = false;
        }

        if (UserInformation.i.Inventory.FindMountingItem(GetUID) == null)
        {
            _realeaseBtn.interactable = false;
            return;
        }
        _moutingBtn.interactable = false;
    }

    private void BuyButton()
    {
        var pop = UIManager.i.CreatePopup<PopupItemRelatedPanel>(POPUP_TYPE.POPUP);
        pop.PopKind = PopupKind.BuyPop;
    }
    public bool Buy()
    {
        int invenMoney = UserInformation.i.Inventory.Money;
        var isBuy = UnitManager.i.ItemBuy(GetIndex, invenMoney);

        if (isBuy == false)
        {
            UIManager.i.CreatePopup<PopupWarning>(POPUP_TYPE.POPUP);
            return false;
        }

        UIManager.i.RemoveStackUIObject<StackItemManagement>();
        UIManager.i.GetPageUIObject<PageMain>().ResetUIUpdata();
        return true;
    }

    private void SellButton()
    {
        UIManager.i.CreatePopup<PopupItemRelatedPanel>(POPUP_TYPE.POPUP).PopKind = PopupKind.SellPop;
    }
    public void Sell()
    {
        UnitManager.i.ItemSell(GetUID);  

        UIManager.i.RemoveTopStackUIObject();
        UIManager.i.GetPageUIObject<PageMain>().ResetUIUpdata();
    }

    private void UpgradeButton()
    {
        UIManager.i.GetStackUIObject<StackUserEquipment>().gameObject.SetActive(false);
        UIManager.i.CreatePopup<StackUpgradePanel>(POPUP_TYPE.STACK).GetUpgradeItemUID = GetUID;
    }

    private void MountingButton()
    {

        var uid = UserInformation.i.Inventory.GetCheckMountItemUID(GetUID);

        UnitManager.i.RealeaseItem(uid);

        UnitManager.i.MountItem(GetUID);

        UIManager.i.RemoveTopStackUIObject();
    }

    private void RealeaseButton()
    {
        UnitManager.i.RealeaseItem(GetUID);
        UIManager.i.RemoveTopStackUIObject();
    }

    public override void ResetUIUpdata()
    {
        //base.ResetUIUpdata();

        ButtonUpdate();
        _itemInfo.SetUIData(GetIndex);
    }

    protected override void OnButtonClick(string name)
    {
        if (name == "Btn_Buy")
        {
            BuyButton();
        }
        if (name == "Btn_Upgrade")
        {
            UpgradeButton();
        }
        if (name == "Btn_Sell")
        {
            SellButton();
        }
        if (name == "Btn_Mounting")
        {
            MountingButton();
        }
        if (name == "Btn_Realease")
        {
            RealeaseButton();
        }
    }
}
