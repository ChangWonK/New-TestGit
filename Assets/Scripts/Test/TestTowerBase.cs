using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTowerBase : MonoBehaviour
{
    public long UID;
    public int Index;
    public string Name;

    public int Power;
    public int Hp;

    public int AddPower;


    public virtual int Attack()
    {
        Debug.Log("Base Attack");
        return Power;
    }
}

public class ManTower : TestTowerBase
{

    public override int Attack()
    {
        var baseAttack = base.Attack();

        Debug.Log("Man Power" + (baseAttack + AddPower) );

        return (baseAttack + AddPower);

    }
}

public class WomenTower : TestTowerBase
{
    public override int Attack()
    {
        var baseAttack = base.Attack();

        Debug.Log("Women Power" + (baseAttack - AddPower));

        return (baseAttack - AddPower);
    }

}
