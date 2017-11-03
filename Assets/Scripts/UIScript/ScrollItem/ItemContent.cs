using UnityEngine;
using UnityEngine.UI;

public class ItemContent : UnitContent
{

    void Awake()
    {
        _rankTxt = GetText("Txt_Rank");
        _levelTxt = GetText("Txt_Level");
        _contentImg = GetComponent<Image>();

        GetComponent<Button>().onClick.AddListener(ButtonAction);
    }

    public override void SetUIData(int index, long uID = 0)
    {
        base.SetUIData(index, uID);

        Utility.i.TextBuilder.Length = 0;
        Utility.i.TextBuilder.Append(Utility.ImagePath);
        Utility.i.TextBuilder.Append(Utility.ImageName);

        if (index ==0)
        {
            Utility.i.TextBuilder.Append(Utility.ItemNull);

            _contentImg.sprite = Resources.Load<Sprite>(Utility.i.TextBuilder.ToString());
            _rankTxt.text = null;
            _levelTxt.text = null;
            return;
        }

        var table = TableManager.i.GetTable<ItemData>(index);

        int itemIndex = (index - 1) / 10;
        Utility.i.TextBuilder.Append(itemIndex);

        _contentImg.sprite = Resources.Load<Sprite>(Utility.i.TextBuilder.ToString());
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
