using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item  : Unit
{
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

    public Item() { }

    public Item(int index)
    {
        var table = TableManager.i.GetTable<ItemData>(index);

        LocalIndex = index;
        Name = table.Name;
        Kind = table.Kind;
        Rank = table.Rank;
        intRank = table.intRank;
        Level = table.Level;
        Cost = table.Cost;

        HumanAtkPower = table.HumanAtkPower;
        HumanAtkSpeed = table.HumanAtkSpeed;
        HumanAtkRange = table.HumanAtkRange;
        HumanMoveSpeed = table.HumanMoveSpeed;

        MachineAtkPower = table.MachineAtkPower;
        MachineAtkSpeed = table.MachineAtkSpeed;
        MachineAtkRange = table.MachineAtkRange;
        MachineMoveSpeed = table.MachineMoveSpeed;

        MagicAtkPower = table.MagicAtkPower;
        MagicAtkSpeed = table.MagicAtkSpeed;
        MagicAtkRange = table.MagicAtkRange;
        MagicMoveSpeed = table.MagicMoveSpeed;

    }

    public Item(int index , long uid)
    {
        UID = uid;

        var table = TableManager.i.GetTable<ItemData>(index);

        LocalIndex = index;
        Name = table.Name;
        Kind = table.Kind;
        Rank = table.Rank;
        intRank = table.intRank;
        Level = table.Level;
        Cost = table.Cost;

        HumanAtkPower = table.HumanAtkPower;
        HumanAtkSpeed = table.HumanAtkSpeed;
        HumanAtkRange = table.HumanAtkRange;
        HumanMoveSpeed = table.HumanMoveSpeed;

        MachineAtkPower = table.MachineAtkPower;
        MachineAtkSpeed = table.MachineAtkSpeed;
        MachineAtkRange = table.MachineAtkRange;
        MachineMoveSpeed = table.MachineMoveSpeed;

        MagicAtkPower = table.MagicAtkPower;
        MagicAtkSpeed = table.MagicAtkSpeed;
        MagicAtkRange = table.MagicAtkRange;
        MagicMoveSpeed = table.MagicMoveSpeed;

    }

        //public Item(Item item)
        //{
        //    UID = item.UID;
        //    LocalIndex = item.LocalIndex;
        //    Name = item.Name;
        //    Kind = item.Kind;
        //    Rank = item.Rank;
        //    Level = item.Level;
        //    Cost = item.Cost;

        //    HumanAtkPower = item.HumanAtkPower;
        //    HumanAtkSpeed = item.HumanAtkSpeed;
        //    HumanAtkRange = item.HumanAtkRange;
        //    HumanMoveSpeed = item.HumanMoveSpeed;
        //    MachineAtkPower = item.MachineAtkPower;
        //    MachineAtkSpeed = item.MachineAtkSpeed;
        //    MachineAtkRange = item.MachineAtkRange;
        //    MachineMoveSpeed = item.MachineMoveSpeed;
        //    MagicAtkPower = item.MagicAtkPower;
        //    MagicAtkSpeed = item.MagicAtkSpeed;
        //    MagicAtkRange = item.MagicAtkRange;
        //    MagicMoveSpeed = item.MagicMoveSpeed;
        //}

    }

