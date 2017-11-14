using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanTower : TowerBase
{
    public override void SetAility()
    {

    }    

    public override void Attack(EnemyBase enemy)
    {
        enemy.Hurt(AtkPower);
    }

    public override void Destroy()
    {
        Debug.Log("Human Destroy");
    }

   

}



