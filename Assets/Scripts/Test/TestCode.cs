using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    private GameObject _prefab;
    public Tower test;

    private GameObject _testPrefab;
    private List<GameObject> _list = new List<GameObject>();

    void Start()
    {
        _prefab = Resources.Load<GameObject>("Prefabs/3DObject/Tower/TowerPrefab");
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "human ADD"))
        {
            
           GameObject newObject = test.SpwanObject(Vector3.zero, Quaternion.identity);
            _list.Add(newObject);
        }

        if (GUI.Button(new Rect(0, 200, 100, 100), "machine ADD"))
        {
            _list[0].Recycle();
            _list.RemoveAt(0);
        }

        if (GUI.Button(new Rect(0, 400, 100, 100), "human Remove"))
        {
            Debug.Log(_list.Count);
        }

        if (GUI.Button(new Rect(0, 600, 100, 100), "machine Remove"))
        {
        }

        if (GUI.Button(new Rect(1180, 000, 100, 100), "human Attack"))
        {
        }
        if (GUI.Button(new Rect(1180, 200, 100, 100), "machine Attack"))
        {
        }

    }
}
