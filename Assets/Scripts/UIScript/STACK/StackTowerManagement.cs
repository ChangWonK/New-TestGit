using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StackTowerManagement : UIPopupBase
{
    private TowerInformation _towerInfo;
    private int _getIndex;
    private long _getUID;

    private Text _skillTxt;

    private Button _upgradeBtn;
    private Button _buyBtn;
    private Button _firstSkillBtn;
    private Button _secondSkillBtn;
    private Button _thirdSkillBtn;

    private TowerData _SelectedTower;
    private SkillContent[] _contentArray;

    void Awake()
    {
        _towerInfo = GetComponentInChildren<TowerInformation>();
        _contentArray = GetComponentsInChildren<SkillContent>();

        _upgradeBtn = RegistButtonOnClickEvent("Btn_Upgrade");
        _buyBtn = RegistButtonOnClickEvent("Btn_Buy");
        _firstSkillBtn = RegistButtonOnClickEvent("Btn_FirstSkill");
        _secondSkillBtn = RegistButtonOnClickEvent("Btn_SecondSkill");
        _thirdSkillBtn = RegistButtonOnClickEvent("Btn_ThirdSkill");

        Transform trans = transform.GetChild(3).transform.Find("AbilityTexts");
        _skillTxt = GetText(trans, "Txt_Skill");

    }



    private void UpgradeButton()
    {
        UIManager.i.CreatePopup<PopupTowerRelatedPanel>(POPUP_TYPE.POPUP).PopKind = PopupKind.UpgradePop;
    }
    public void Upgrade()
    {
        _getIndex = UnitManager.i.UITowerUpgrade(_getUID);
        UpdateData(_getIndex);
    }

    private void BuyButton()
    {
        UIManager.i.CreatePopup<PopupTowerRelatedPanel>(POPUP_TYPE.POPUP).PopKind = PopupKind.BuyPop;
    }
    public void Buy()
    {
        if (_getIndex >= 100)
            UnitManager.i.UITowerBuy<HumanTower>(_getIndex);
        else if (_getIndex >= 200)
            UnitManager.i.UITowerBuy<MachineTower>(_getIndex);
        else if (_getIndex >= 300)
            UnitManager.i.UITowerBuy<MagicTower>(_getIndex);

        UpdateData(_getIndex);
    }

    private void SetContent()
    {
        _SelectedTower = TableManager.i.GetTable<TowerData>(_getIndex);

        _contentArray[0].SetUIData(_SelectedTower.FirstSkillIndex);
        _contentArray[1].SetUIData(_SelectedTower.SecondSkillIndex);
        _contentArray[2].SetUIData(_SelectedTower.ThirdSkillIndex);

        for (int i = 0; i < 3; i++)
            _contentArray[i].Callback = ContentClickEvent;
    }

    private void ContentClickEvent(int skillIndex, long UID = 0)
    {
        var skill = TableManager.i.GetTable<SkillData>(skillIndex);
        _skillTxt.text = skill.Skill;
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

        SetContent();

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
    }
}
