using UnityEngine;

public abstract class TowerBase 
{
    public long UID;
    public int LocalIndex;
    public string Name;
    public string Kind;
    public string Rank;
    public int intRank;
    public int Level;
    public int Cost;

    public float AtkPower;
    public float AtkSpeed;
    public float AtkRange;
    public float MoveSpeed;

    public int FirstSkillIndex;
    public int SecondSkillIndex;
    public int ThirdSkillIndex;


    public void Init(int index)
    {
        var table = TableManager.i.GetTable<TowerData>(index);

        UID = (index + 11) / 10;


        LocalIndex = index;
        Name = table.Name;
        Kind = table.Species;
        Rank = table.Rank;
        //intRank = table.intRank;
        Level = table.Level;
        Cost = table.Cost;

        AtkPower = table.AtkPower;
        AtkSpeed = table.AtkSpeed;
        AtkRange = table.AtkRange;
        MoveSpeed = table.MoveSpeed;

        FirstSkillIndex = table.FirstSkillIndex;
        SecondSkillIndex = table.SecondSkillIndex;
        ThirdSkillIndex = table.ThirdSkillIndex;
    }

    public abstract void SetAility();

    public abstract float Attack();

    public abstract void Destroy();

    //public abstract void AddBuf();

}
