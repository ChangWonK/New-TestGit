using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerContent : UnitContent
{
    void Awake ()
    {
        _rankTxt = GetText("Txt_Rank");
        _levelTxt = GetText("Txt_Level");

        GetComponent<Button>().onClick.AddListener(ButtonAction);
	}

    public override void SetUIData(int index, long uID = 0)
    {
        base.SetUIData(index, uID);

        Utility.i.TextBuilder.Length = 0;
        Utility.i.TextBuilder.Append(Utility.TowerPath);
        Utility.i.TextBuilder.Append(Utility.TowerName);

        if (index == 0)
            return;

        var table = TableManager.i.GetTable<TowerData>(index);

        _rankTxt.text = table.Rank;

        if (table.Level >= 10)
            _levelTxt.text = Utility.LevelGrade + "Max";
        else
            _levelTxt.text = Utility.LevelGrade + table.Level.ToString();
    }

    public override void ButtonAction()
    {
        if (_index == 0) return;

        if (Callback != null)
            Callback.Invoke(_index, _uID);
    }

	
	
	
}
