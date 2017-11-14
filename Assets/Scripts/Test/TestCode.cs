using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    public GameObject TestObject;

    public List<TestTower> _towerList = new List<TestTower>();


    public void ddd(TestTower tower)
    {
        tower.move();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "human ADD"))
        {
            GameObject newObject =  Instantiate(TestObject);
            GameObject nexwObject = Instantiate(TestObject);

            newObject.AddComponent<Vayne>();
            nexwObject.AddComponent<Zealot>();

            _towerList.Add(newObject.GetComponent<TestTower>());
            _towerList.Add(nexwObject.GetComponent<TestTower>());


        }

        if (GUI.Button(new Rect(0, 200, 100, 100), "machine ADD"))
        {
            _towerList[0].Attack();
        }

        if (GUI.Button(new Rect(0, 400, 100, 100), "human Remove"))
        {
            ddd(_towerList[0]);

        }

        if (GUI.Button(new Rect(0, 600, 100, 100), "machine Remove"))
        {
            ddd(_towerList[1]);
        }


        if (GUI.Button(new Rect(1180, 000, 100, 100), "human Attack"))
        {
        }
        if (GUI.Button(new Rect(1180, 200, 100, 100), "machine Attack"))
        {
        }

    }
}
