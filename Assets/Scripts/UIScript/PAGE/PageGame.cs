using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageGame : UIPopupBase
{
    private Text _modeTxt;
    private Text _stageTxt;

    void Awake()
    {
        Transform textTrans = transform.Find("Text");
        _modeTxt = GetText("Txt_Mode");
        _stageTxt = GetText("Txt_Stage");
    }

    void Start ()
    {
        _modeTxt.text = GameManager.i.GameMode.ToString();
        _stageTxt.text = GameManager.i.GameStage.ToString() + " - " + GameManager.i.GameMap.ToString();
    }
	
}
