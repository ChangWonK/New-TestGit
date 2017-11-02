using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTower : TowerBase
{
    public MagicTower(int index)
    {
    }
    public MagicTower() { }

    public override void SetAility()
    {
        AtkPower += UserInformation.i.Character.GetMagicAtkPower() * AtkPower;
        AtkSpeed += UserInformation.i.Character.GetMagicAtkSpeed() * AtkSpeed;
        AtkRange += UserInformation.i.Character.GetMagicAtkRange() * AtkRange;
        MoveSpeed += UserInformation.i.Character.GetMagicMoveSpeed() * MoveSpeed;
    }

    public override float Attack()
    {
        Debug.Log("magic atk : " + AtkPower);
        return AtkPower;
    }
}
