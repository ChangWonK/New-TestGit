using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTower : TowerBase
 {
    public override void SetAility()
    {
        AtkPower += UserInformation.i.Character.GetMachineAtkPower() * AtkPower;
        AtkSpeed += UserInformation.i.Character.GetMachineAtkSpeed() * AtkSpeed;
        AtkRange += UserInformation.i.Character.GetMachineAtkRange() * AtkRange;
        MoveSpeed += UserInformation.i.Character.GetMachineMoveSpeed() * MoveSpeed;
    }

    public override void Attack(EnemyBase enemy)
    {
        enemy.Hurt(AtkPower);
    }

    public override void Destroy()
    {
        Debug.Log("Machine Destroy");
    }
}
