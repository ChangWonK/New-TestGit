using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    private string PoolItemName = string.Empty;
    public List<GameObject> _outPool = new List<GameObject>();
    public Tower TowerPrefab;

    void Start ()
    {
        UnitManager.i.UITowerBuy<HumanTower>(1);
        UnitManager.i.UITowerBuy<MachineTower>(101);

        UnitManager.i.ItemBuy(1);
        UnitManager.i.ItemBuy(101);

        UnitManager.i.ItemMounting(1);
        UnitManager.i.ItemMounting(2);

        UserInformation.i.Character.Init();
    }


    void TestTowerBuild<T>(int index) where T : TowerBase, new()
    {
        var newTower = Instantiate(TowerPrefab);

        newTower = UnitManager.i.TowerBuild<T>(newTower, index);

        newTower.Attack();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "humanTower"))
        {
            TestTowerBuild<HumanTower>(1);
        }

        if (GUI.Button(new Rect(0, 200, 100, 100), "Instansite"))
        {
            TestTowerBuild<MachineTower>(11);

            //var newTower = Instantiate(TowerPrefab);
            //newTower.GetComponent<Tower>().TowerBase = new MachineTower(1);
            //newTower.GetComponent<Tower>().TowerBase.Init(11);
            //newTower.GetComponent<Tower>().Init();
            //newTower.GetComponent<Tower>().Attack();
        }

        if (GUI.Button(new Rect(0, 400, 100, 100), "Instansite"))
        {
            
        }

        //if(GUI.Button(new Rect(0,0,100,100), "Instansite"))
        //{
        //    var effect = ObjectPool.i.SpwanObject();

        //    if(effect)
        //    {
        //        effect.transform.position = Vector3.zero;
        //        _outPool.Add(effect);
        //    }
        //}


        //if (GUI.Button(new Rect(0, 200, 100, 100), "SpwaPool"))
        //{
        //    GameObject obj = null;

        //    if (_outPool.Count > 0)
        //    {
        //        obj = _outPool[0];
        //        _outPool.RemoveAt(0);
        //    }

        //    ObjectPool.i.Recycle(obj);
        //}

    }
}
