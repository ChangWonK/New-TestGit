using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum ContentIndex
{
    ITEM = 0, TOWER, SKILL
}
public enum GameKind
{
    NORMAL = 0, FREE, CHALLENGE
}

public abstract class UnitContent : UIObject
{
    public UnityAction<int,long> Callback;

    protected Image _contentImg;

    protected Text _rankTxt;
    protected Text _levelTxt;

    protected long _uID;
    protected int _index;


    public virtual void SetUIData(int index, long uID = 0)
    {
        _index = index;
        _uID = uID;
    }

    public abstract void ButtonAction();

   
}
