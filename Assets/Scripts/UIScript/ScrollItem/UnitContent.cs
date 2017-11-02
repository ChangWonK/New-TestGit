using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ContentIndex
{
    ITEM = 0, TOWER
}

public abstract class UnitContent : UIObject
{
    protected Image _imgUnitContent;
    protected Text _textRank;
    protected Text _textLevel;

    protected long _uID;
    protected int _index;


    public virtual void SetUIData(int index, long uID = 0)
    {
        _index = index;
        _uID = uID;
    }
   
}
