using UnityEngine;
using System.Collections;
using System;
using System.Xml;


// 엑셀 시트이름과 같이 할것 
public class TowerData : Table<TowerData> , ITableRow
{
    public const string PrefabPath = Utility.TowerContentPath;

    public int LocalIndex;
    public string Name;
    public string Species;
    public string Rank;
    public int Level;
    public float AtkPower;
    public float AtkSpeed;
    public float AtkRange;
    public float MoveSpeed;    
    public int Cost;

    public int FirstSkillIndex;
    public int SecondSkillIndex;
    public int ThirdSkillIndex;


    public int ID
    {
        get
        {
            return LocalIndex;
        }
    }

    public void Parse(XmlNode node)
    {   
        LocalIndex = node.GetInt("LocalIndex");
        Name = node.GetString("Name");
        Species = node.GetString("Species");
        Rank = node.GetString("Rank");
        Level = node.GetInt("Level");
        AtkPower = node.GetFloat("AtkPower");
        AtkSpeed = node.GetFloat("AtkSpeed");
        AtkRange = node.GetFloat("AtkRange");
        MoveSpeed = node.GetFloat("MoveSpeed");
        Cost = node.GetInt("Cost");
        FirstSkillIndex = node.GetInt("FirstSkillIndex");
        SecondSkillIndex = node.GetInt("SecondSkillIndex");
        ThirdSkillIndex = node.GetInt("ThirdSkillIndex");
    }
}

public class ItemData : Table<ItemData>, ITableRow
{
    public const string PrefabPath = Utility.ItemContentPath;

    public int LocalIndex;
    public string Name;
    public string Kind;
    public string Rank;
    public int intRank;
    public int Level;
    public int Cost;

    public float HumanAtkPower;
    public float HumanAtkSpeed;
    public float HumanAtkRange;
    public float HumanMoveSpeed;
    public float MachineAtkPower;
    public float MachineAtkSpeed;
    public float MachineAtkRange;
    public float MachineMoveSpeed;
    public float MagicAtkPower;
    public float MagicAtkSpeed;
    public float MagicAtkRange;
    public float MagicMoveSpeed;

    public int ID
    {
        get
        {
            return LocalIndex;
        }
    }

    public void Parse(XmlNode node)
    {
        LocalIndex = node.GetInt("LocalIndex");
        Name = node.GetString("Name");
        Kind = node.GetString("Kind");
        Rank = node.GetString("Rank");
        intRank = node.GetInt("intRank");
        Level = node.GetInt("Level");
        Cost = node.GetInt("Cost");


        HumanAtkPower = node.GetFloat("HumanAtkPower");
        HumanAtkSpeed = node.GetFloat("HumanAtkSpeed");
        HumanAtkRange = node.GetFloat("HumanAtkRange");
        HumanMoveSpeed = node.GetFloat("HumanMoveSpeed");

        MachineAtkPower = node.GetFloat("MachineAtkPower");
        MachineAtkSpeed = node.GetFloat("MachineAtkSpeed");
        MachineAtkRange = node.GetFloat("MachineAtkRange");
        MachineMoveSpeed = node.GetFloat("MachineMoveSpeed");

        MagicAtkPower = node.GetFloat("MagicAtkPower");
        MagicAtkSpeed = node.GetFloat("MagicAtkSpeed");
        MagicAtkRange = node.GetFloat("MagicAtkRange");
        MagicMoveSpeed = node.GetFloat("MagicMoveSpeed");

    }
}

public class SkillData : Table<SkillData>, ITableRow
{
    public const string PrefabPath = "Prefabs/UI/ScrollItem/TowerContent";

    public int LocalIndex;
    public string Name;

    public int ID
    {
        get
        {
            return LocalIndex;
        }
    }

    public void Parse(XmlNode node)
    {
        LocalIndex = node.GetInt("LocalIndex");
        Name = node.GetString("Name");
    }
}
