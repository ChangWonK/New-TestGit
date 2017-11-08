using UnityEngine.UI;

public class PopupItemRelatedPanel : UIPopupBase
{
    public PopupKind PopKind = 0;

    private Text _questionTxt;

    void Awake()
    {
        _questionTxt = GetText("Txt_Question");
    }

    void Start()
    {
        RegistAllButtonOnClickEvent();

        if(PopKind == PopupKind.UpgradePop)
            _questionTxt.text = Utility.UpgradeQuestion;
        if (PopKind == PopupKind.BuyPop)
            _questionTxt.text = Utility.BuyQuestion;
        if(PopKind == PopupKind.SellPop)
            _questionTxt.text = Utility.SellQuestion;
    }

    private void UpgradeButton()
    {
        UIManager.i.GetStackUIObject<StackUpgradePanel>().Combination();
        UIManager.i.RemovePopupUIObject<PopupItemRelatedPanel>();
    }

    private void BuyButton()
    {
        if(UIManager.i.GetStackUIObject<StackItemManagement>().Buy())
        {
            UIManager.i.RemovePopupUIObject<PopupItemRelatedPanel>();
        }
    }

    private void SellButton()
    {
        UIManager.i.GetStackUIObject<StackItemManagement>().Sell();
        UIManager.i.RemovePopupUIObject<PopupItemRelatedPanel>();
    }

    private void NoButton()
    {
        UIManager.i.RemovePopupUIObject<PopupItemRelatedPanel>();
    }

    protected override void OnButtonClick(string name)
    {
        base.OnButtonClick(name);

        if (name == "Btn_Yes")
        {
            if (PopKind == PopupKind.UpgradePop)
                UpgradeButton();
            if (PopKind == PopupKind.BuyPop)
                BuyButton();
            if (PopKind == PopupKind.SellPop)
                SellButton();
        }
        if (name == "Btn_No")
        {
            NoButton();
        }
    }
}
