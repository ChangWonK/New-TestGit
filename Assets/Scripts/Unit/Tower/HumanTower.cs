﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanTower : TowerBase
{
    public override void SetAility()
    {
        AtkPower += UserInformation.i.Character.GetHumanAtkPower() * AtkPower;
        AtkSpeed += UserInformation.i.Character.GetHumanAtkSpeed() * AtkSpeed;
        AtkRange += UserInformation.i.Character.GetHumanAtkRange() * AtkRange;
        MoveSpeed += UserInformation.i.Character.GetHumanMoveSpeed() * MoveSpeed;
    }

    public override float Attack()
    {
        Debug.Log("Human AttackPower : " + AtkPower);
        return AtkPower;
    }

    public override void Destroy()
    {
        Debug.Log("Human Destroy");
    }

}


