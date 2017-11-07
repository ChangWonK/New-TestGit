using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StageContent : MonoBehaviour
{
    public UnityAction<GameKind, int> CallBack;
    private GameKind _gameKind;
    private int _mapLevel;


    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ButtonAction);
    }

    public void SetUIData(GameKind gameKind, int mapLevel)
    {
        _gameKind = gameKind;
        _mapLevel = mapLevel;
    }

    public void ButtonAction()
    {
        if (CallBack != null)
            CallBack.Invoke(_gameKind, _mapLevel);
    }

}
