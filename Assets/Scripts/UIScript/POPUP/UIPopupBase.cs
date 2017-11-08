using UnityEngine;
public enum PopupKind { UpgradePop = 0, BuyPop, SellPop, PlayGame, }

public class UIPopupBase : UIObject
{
    [HideInInspector]
    public POPUP_TYPE TYPE;


    public virtual void ResetUIUpdata()
    {
        gameObject.SetActive(true);
    }

    public virtual void RemovedUIObject()
    {
        Destroy(gameObject);
    }

}
    