using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTower : TowerBase
 {
    public MachineTower(int index)
    {
    }
    public MachineTower() { }

    public override void SetAility()
    {
        Debug.Log(AtkPower);
        AtkPower += UserInformation.i.Character.GetMachineAtkPower() * AtkPower;
        AtkSpeed += UserInformation.i.Character.GetMachineAtkSpeed() * AtkSpeed;
        AtkRange += UserInformation.i.Character.GetMachineAtkRange() * AtkRange;
        MoveSpeed += UserInformation.i.Character.GetMachineMoveSpeed() * MoveSpeed;
    }

    public override float Attack()
    {
        Debug.Log("machine atk : " + AtkPower);
        return AtkPower;
    }
}
