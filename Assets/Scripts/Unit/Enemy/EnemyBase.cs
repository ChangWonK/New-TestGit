using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int LocalIndex;

    public int Life;
    public int Armor;
    public float MoveSpeed;
    public int GetMoney;

    public void Init(int index)
    {
       var table = TableManager.i.GetTable<EnemyData>(index);

        LocalIndex = table.LocalIndex;

        Life = table.Life;
        Armor = table.Armor;
        MoveSpeed = table.MoveSpeed;
        GetMoney = table.GetMoney;
    }

    public virtual void Hurt(float damage)
    {
        Debug.Log("Hurt Damage : " + damage);
    }


}
