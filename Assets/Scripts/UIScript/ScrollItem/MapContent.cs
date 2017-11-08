using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MapContent : UIObject {

    private Text _nameTxt;
    private int _mapLevel;

    public UnityAction<int> CallBack;

    void Awake()
    {
        _nameTxt = GetText("Text");
        GetComponent<Button>().onClick.AddListener(ButtonAction);
    }

    public void SetUIData(int mapLevel)
    {
        _mapLevel = mapLevel;
    }

    public void ButtonAction()
    {
        if (CallBack != null)
            CallBack.Invoke(_mapLevel);
    }
}
