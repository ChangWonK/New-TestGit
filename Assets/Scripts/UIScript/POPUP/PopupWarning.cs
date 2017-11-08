using System.Collections;
using UnityEngine;

public class PopupWarning : UIPopupBase {

    void Start()
    {
        StartCoroutine(WarningTime());
    }

   private IEnumerator WarningTime()
    {
        yield return new WaitForSeconds(1.5f);

        UIManager.i.RemovePopupUIObject<PopupWarning>();
    }
}
