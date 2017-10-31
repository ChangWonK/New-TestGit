using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StackTowerManagement : UIPopupBase
{
    private TowerInformation _towerInfo;
    private int _getIndex;
    private long _getUID;

    private Button _upgradeBtn;
    private Button _buyBtn;
    private Button _firstSkillBtn;
    private Button _secondSkillBtn;
    private Button _thirdSkillBtn;

    void Awake()
    {
        _towerInfo = GetComponentInChildren<TowerInformation>();

        _upgradeBtn = RegistButtonOnClickEvent("Btn_Upgrade");
        _buyBtn = RegistButtonOnClickEvent("Btn_Buy");
        _firstSkillBtn = RegistButtonOnClickEvent("Btn_FirstSkill");
        _secondSkillBtn = RegistButtonOnClickEvent("Btn_SecondSkill");
        _thirdSkillBtn = RegistButtonOnClickEvent("Btn_ThirdSkill");
    }

    private void UpgradeButton()
    {
        UIManager.i.CreatePopup<PopupTowerRelatedPanel>(POPUP_TYPE.POPUP).PopKind = PopupKind.UpgradePop;
    }
    public void Upgrade()
    {
        _getIndex = UnitManager.i.TowerUpgrade(_getUID);
        UpdateData(_getIndex);
    }
    private void BuyButton()
    {
        UIManager.i.CreatePopup<PopupTowerRelatedPanel>(POPUP_TYPE.POPUP).PopKind = PopupKind.BuyPop;
    }
    public void Buy()
    {
        UnitManager.i.TowerBuy(_getIndex);
        UpdateData(_getIndex);
    }

    private void FirstSkillButton()
    {

    }
    private void SecondSkillButton()
    {

    }
    private void ThirdSkillButton()
    {
    }

    private void UpdateButton()
    {
        TowerBase tower = UserInformation.i.Inventory.FindTower(_getUID);

        if (tower == null)
        {
            _upgradeBtn.interactable = false;
            _buyBtn.interactable = true;
        }
        else
        {
            _upgradeBtn.interactable = true;
            _buyBtn.interactable = false;

            if (tower.Level < 10) _upgradeBtn.interactable = true;
            else _upgradeBtn.interactable = false;
        }
    }

    public void UpdateData(int index)
    {
        _getUID = (index + 11) / 10;
        _getIndex = index;

        if (UserInformation.i.Inventory.FindTower(_getUID) != null)
            _getIndex = UserInformation.i.Inventory.FindTower(_getUID).LocalIndex;

        _towerInfo.SetUIData(_getIndex);

        UpdateButton();

    }

    protected override void OnButtonClick(string name)
    {
        base.OnButtonClick(name);

        if (name == "Btn_Upgrade")
        {
            UpgradeButton();
        }
        if (name == "Btn_Buy")
        {
            BuyButton();
        }
        if (name == "Btn_FirstSkill")
        {
            FirstSkillButton();
        }
        if (name == "Btn_SecondSkill")
        {
            SecondSkillButton();
        }
        if (name == "Btn_ThirdSkill")
        {
            ThirdSkillButton();
        }
    }
}
