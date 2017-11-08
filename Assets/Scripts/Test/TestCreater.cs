using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCreater : MonoBehaviour
{
    private Vector3 _spwanPos = new Vector3(0,0,0);


    private GameObject _towerRes;

	
	void Start ()
    {
        _towerRes = Resources.Load<GameObject>("TestCube");

    }


    private void AddCurrentpos()
    {
        _spwanPos += new Vector3(1,0,0);

    }
	
	void OnGUI ()
    {
        if(GUI.Button(new Rect(0,0,100,100), "Tower Make"))
        {
            TestTowerManager.i.CreateTower<ManTower>(_towerRes,_spwanPos,Quaternion.identity);
            AddCurrentpos();
        }

        if (GUI.Button(new Rect(100, 0, 100, 100), "Tower Remove"))
        {
            var firstObject = TestTowerManager.i.GetFirstTower();

            TestTowerManager.i.RemoveTower(firstObject);
        }

    }
}
