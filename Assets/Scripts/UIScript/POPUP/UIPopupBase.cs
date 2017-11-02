public class UIPopupBase : UIObject
{
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
    