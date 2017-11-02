using UnityEngine;
using UnityEngine.UI;

public class ItemContent : UnitContent
{
    void Awake()
    {
        _textRank = GetText("Txt_Rank");
        _textLevel = GetText("Txt_Level");
        _imgUnitContent = GetComponent<Image>();

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

            _imgUnitContent.sprite = Resources.Load<Sprite>(Utility.i.TextBuilder.ToString());
            _textRank.text = null;
            _textLevel.text = null;
            return;
        }

        var table = TableManager.i.GetTable<ItemData>(index);

        int itemIndex = (index - 1) / 10;
        Utility.i.TextBuilder.Append(itemIndex);

        _imgUnitContent.sprite = Resources.Load<Sprite>(Utility.i.TextBuilder.ToString());
        _textRank.text = table.Rank;

        if (table.Level >= 10)
            _textLevel.text = Utility.LevelGrade + "Max";
        else
            _textLevel.text = Utility.LevelGrade + table.Level.ToString();
    }
 

    public void ButtonAction()
    {
        if (UIManager.i.GetStackUIObject<StackItemShop>())
        {
           var pop = UIManager.i.CreatePopup<StackItemManagement>(POPUP_TYPE.STACK);
            pop.Init<StackItemShop>(_index);
        }
        else if (UIManager.i.GetStackUIObject<StackUpgradePanel>())
        {
            var pop = UIManager.i.GetStackUIObject<StackUpgradePanel>();
            pop.UpdateData(_uID);
        }
        else if (UIManager.i.GetStackUIObject<StackUserEquipment>())
        {
            var pop = UIManager.i.CreatePopup<StackItemManagement>(POPUP_TYPE.STACK);
            pop.Init<StackUserEquipment>(_index, _uID);
        }
   
    }
}
