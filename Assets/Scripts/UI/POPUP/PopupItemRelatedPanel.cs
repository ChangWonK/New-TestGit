using UnityEngine.UI;

public enum PopupKind { UpgradePop =0, BuyPop, SellPop}

public class PopupItemRelatedPanel : UIPopupBase
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

        if(PopKind == PopupKind.UpgradePop)
            _textQuestion.text = Utility.UpgradeQuestion;
        if (PopKind == PopupKind.BuyPop)
            _textQuestion.text = Utility.BuyQuestion;
        if(PopKind == PopupKind.SellPop)
            _textQuestion.text = Utility.SellQuestion;
    }

    private void UpgradeButtonYes()
    {
        UIManager.i.GetStackUIObject<StackUpgradePanel>().Combination();
        UIManager.i.RemoveTopPopupUIObject();
    }

    private void BuyButtonYes()
    {
        UIManager.i.GetStackUIObject<StackItemManagement>().Buy();
        UIManager.i.RemoveTopPopupUIObject();
    }

    private void SellButtonYes()
    {
        UIManager.i.GetStackUIObject<StackItemManagement>().Sell();
        UIManager.i.RemoveTopPopupUIObject();
    }

    private void ButtonNo()
    {
        UIManager.i.RemoveTopPopupUIObject();
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
            if (PopKind == PopupKind.SellPop)
                SellButtonYes();
        }
        if (name == "Btn_No")
        {
            ButtonNo();
        }
    }
}
