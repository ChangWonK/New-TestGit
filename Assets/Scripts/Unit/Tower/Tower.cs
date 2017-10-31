using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    TowerBase tb = new TowerBase();
	// Use this for initialization
	void Start () {

        tb.SetAtkPower();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
