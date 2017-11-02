using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private enum States { WATING = 0, ATTACK, BUILD, MOVE }

    public TowerBase TowerBase;

    private States _state = States.BUILD;

    void Update()
    {

    }

    public void Init()
    {
        TowerBase.SetAility();
    }

    public void Attack()
    {
        TowerBase.Attack();
    }



}
