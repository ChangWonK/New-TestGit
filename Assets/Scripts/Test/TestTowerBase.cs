using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class TestTower : MonoBehaviour, MoveTowerA, StopTowerA
{
    public int power;
    public int addPower;

    void Awake()
    {
        SetPower();
    }
    void Update()
    {
        UpdateState();
    }

    public abstract void UpdateState();
    public abstract void SetPower();
    public abstract void Attack();
    public abstract void Stop();
    public abstract void move();
}

public abstract class TestHumanTower : TestTower
{
    public override void SetPower()
    {
        Debug.Log("휴먼 업글");
    }

}

public abstract class TestMagicTower : TestTower
{
    public override void SetPower()
    {
        Debug.Log("매직 업글");
    }

}



public abstract class sdsdmoveTower : TestTower
{
    public override void move()
    {
    }
}


sealed public class Vayne : TestHumanTower
{
    public override void Attack()
    {
        Debug.Log("베인 어택");
    }

    public override void move()
    {
        Debug.Log("베인 이동");
    }

    public override void Stop()
    {
        Debug.Log("베인 스톱");
    }

    public override void UpdateState()
    {
        Debug.Log("나베인인데?");
    }

    void Start()
    {
        power = 10;
    }
}

sealed public class Zealot : TestMagicTower
{
    public override void Attack()
    {
        Debug.Log("Zealot 어택");
    }

    public override void move()
    {
        Debug.Log("Zealot 이동");
    }

    public override void Stop()
    {
        Debug.Log("Zealot 스톱");
    }

    public override void UpdateState()
    {
        Debug.Log("나 질럿인데?");

    }

    void Start()
    {
        power = 10;
    }
}


public interface MoveTowerA
{
    void move();
}
public interface StopTowerA
{
    void Stop();
}


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
    public virtual void UpdateMode()

    { }

    internal void move()
    {
        throw new NotImplementedException();
    }
}





public class ManTower : TestTowerBase, MoveTowerA, StopTowerA
{
    public override void UpdateMode()
    {
        base.UpdateMode();
        move();
       
    }

    public override int Attack()
    {
        var baseAttack = base.Attack();
        Debug.Log("Man Attack");


        AddPower = 10;
        return (baseAttack + AddPower);
    }

    public void move()
    {
        throw new NotImplementedException();
    }

    public void Stop()
    {
        throw new NotImplementedException();
    }

}

public class Dron : ManTower
{
    public override int Attack()
    {
        base.Attack();
        Debug.Log("Dron Attack");

        return 1;

    }
}

public class StopTower : ManTower
{
    public override int Attack()
    {
        return base.Attack();
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
