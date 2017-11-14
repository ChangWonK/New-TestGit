using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTower : TowerBase
{
    public override void Attack(EnemyBase enemy)
    {
    }
    public override void Destroy()
    {
        throw new NotImplementedException();
    }
    public override void SetAility()
    {
        if (Kind == "Human")
        {
            AtkPower += UserInformation.i.Character.GetHumanAtkPower() * AtkPower;
            AtkSpeed += UserInformation.i.Character.GetHumanAtkSpeed() * AtkSpeed;
            AtkRange += UserInformation.i.Character.GetHumanAtkRange() * AtkRange;
            MoveSpeed += UserInformation.i.Character.GetHumanMoveSpeed() * MoveSpeed;
        }
        if (Kind == "Machine")
        {
            AtkPower += UserInformation.i.Character.GetMachineAtkPower() * AtkPower;
            AtkSpeed += UserInformation.i.Character.GetMachineAtkSpeed() * AtkSpeed;
            AtkRange += UserInformation.i.Character.GetMachineAtkRange() * AtkRange;
            MoveSpeed += UserInformation.i.Character.GetMachineMoveSpeed() * MoveSpeed;
        }
        if (Kind == "Magic")
        {
            AtkPower += UserInformation.i.Character.GetMagicAtkPower() * AtkPower;
            AtkSpeed += UserInformation.i.Character.GetMagicAtkSpeed() * AtkSpeed;
            AtkRange += UserInformation.i.Character.GetMagicAtkRange() * AtkRange;
            MoveSpeed += UserInformation.i.Character.GetMagicMoveSpeed() * MoveSpeed;
        }
    }
}
