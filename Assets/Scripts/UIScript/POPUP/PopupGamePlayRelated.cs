using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopupGamePlayRelated : UIPopupBase
{
    private Text _questionTxt;

    void Awake()
    {
        _questionTxt = GetText("Txt_Question");
    }

    void Start()
    {
        RegistAllButtonOnClickEvent();
    }

    private void PlayGameButton()
    {
        var pop = UIManager.i.GetStackUIObject<StackMapSelect>();
        pop.SceneChange();
    }

    private void NoButton()
    {
        UIManager.i.RemovePopupUIObject<PopupGamePlayRelated>();
    }



    protected override void OnButtonClick(string name)
    {
        base.OnButtonClick(name);

        if (name == "Btn_Yes")
        {
            PlayGameButton();
        }
        if (name == "Btn_No")
        {
            NoButton();
        }
    }


}
