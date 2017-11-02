using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerContent : UnitContent
{
    void Awake ()
    {
        _textRank = GetText("Txt_Rank");
        _textLevel = GetText("Txt_Level");

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

        _textRank.text = table.Rank;

        if (table.Level >= 10)
            _textLevel.text = Utility.LevelGrade + "Max";
        else
            _textLevel.text = Utility.LevelGrade + table.Level.ToString();
    }

    public void ButtonAction()
    {
        var popup = UIManager.i.CreatePopup<StackTowerManagement>(POPUP_TYPE.STACK);
        popup.UpdateData(_index);
    }

	
	
	
}
