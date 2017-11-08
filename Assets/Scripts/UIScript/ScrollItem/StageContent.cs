using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StageContent : UIObject
{
    private Text _nameTxt;
    private GameMode _gameMode;
    private int _stageLevel;

    public UnityAction<GameMode, int> CallBack;

    void Awake()
    {
        _nameTxt = GetText("Text");
        GetComponent<Button>().onClick.AddListener(ButtonAction);
    }

    public void SetUIData(GameMode gameKind, int stageLevel)
    {
        _gameMode = gameKind;
        _stageLevel = stageLevel;
    }

    public void ButtonAction()
    {
        if (CallBack != null)
            CallBack.Invoke(_gameMode, _stageLevel);
    }

}
