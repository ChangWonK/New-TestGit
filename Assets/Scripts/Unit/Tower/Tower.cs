﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private enum States { WATING = 0, ATTACK, BUILD, MOVE }

    public TowerBase TowerBase;

    private States _currentState = States.BUILD;

    void Update()
    {

        switch(_currentState)
        {
            case States.WATING:
                {

                    
                }
                break;
            case States.ATTACK:
                {

                }
                break;
            case States.BUILD:
                {

                }
                break;
            case States.MOVE:
                {

                }
                break;
        }


    }

    public void UpdateStates()
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
