using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PopupTowerRelatedPanel : UIPopupBase
{
    public PopupKind PopKind = 0;

    private Text _textQuestion;

    void Awake()
    {
        _textQuestion = GetText("Txt_Question");
    }

    void Start()
    {
        RegistAllButtonOnClickEvent();

        if (PopKind == PopupKind.UpgradePop)
            _textQuestion.text = Utility.UpgradeQuestion;
        if (PopKind == PopupKind.BuyPop)
            _textQuestion.text = Utility.BuyQuestion;
    }

    private void UpgradeButtonYes()
    {
        UIManager.i.GetStackUIObject<StackTowerManagement>().Upgrade();
        UIManager.i.RemovePopupUIObject<PopupTowerRelatedPanel>();

    }

    private void BuyButtonYes()
    {
        UIManager.i.GetStackUIObject<StackTowerManagement>().Buy();
        UIManager.i.RemovePopupUIObject<PopupTowerRelatedPanel>();
    }

    private void ButtonNo()
    {
        UIManager.i.RemovePopupUIObject<PopupTowerRelatedPanel>();
    }

    protected override void OnButtonClick(string name)
    {
        base.OnButtonClick(name);

        if (name == "Btn_Yes")
        {
            if (PopKind == PopupKind.UpgradePop)
                UpgradeButtonYes();
            if (PopKind == PopupKind.BuyPop)
                BuyButtonYes();
        }
        if (name == "Btn_No")
        {
            ButtonNo();
        }
    }
}
