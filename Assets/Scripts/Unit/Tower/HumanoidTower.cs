using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidTower : TowerBase
{
    public override void SetAtkPower()
    {
        AtkPower *= UserInformation.i.Character.GetHumanAtkPower();
    }
    public override void SetAtkSpeed()
    {
        AtkSpeed *= UserInformation.i.Character.GetHumanAtkSpeed();
    }
    public override void SetAtkMoveSpeed()
    {
        AtkRange *= UserInformation.i.Character.GetHumanAtkRange();
    }
}
