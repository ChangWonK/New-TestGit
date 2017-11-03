using UnityEngine.UI;

public class SkillContent : UnitContent
{
    private Text _textName;

    void Awake()
    {
        _textName = GetText("Txt_Name");

        GetComponent<Button>().onClick.AddListener(ButtonAction);
    }

    public override void SetUIData(int index, long uID = 0)
    {
        base.SetUIData(index, uID);

        if (index == 0) return;

        var table = TableManager.i.GetTable<SkillData>(index);

        _textName.text = table.Name;
    }

    public override void ButtonAction()
    {
        if (_index == 0) return;

        if (Callback != null)
            Callback.Invoke(_index,_uID);

    }

}
