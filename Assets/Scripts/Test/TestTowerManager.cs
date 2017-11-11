using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTowerManager : MonoSingleton<TestTowerManager>
{
    private long _nextUID = 0;

    private Dictionary<long, GameObject> _liveTowerList = new Dictionary<long, GameObject>();
    private Dictionary<long, TestTowerBase> _liveTowerInfoList = new Dictionary<long, TestTowerBase>();


    //public T CreateTower<T>(GameObject res, Vector3 pos, Quaternion rot) where T : TestTowerBase
    //{
    //    GameObject spwObj = SimpleObjectPool.SpawnPoolObject(res, pos, rot);

    //    T tower = spwObj.GetComponent<T>();        

    //    if (tower == null)
    //        tower = spwObj.AddComponent<T>();
        
    //    tower.UID = GetNextUID();

    //    if (_liveTowerList.ContainsKey(tower.UID) == false)
    //    {
    //        _liveTowerList.Add(tower.UID , spwObj);
    //        _liveTowerInfoList.Add(tower.UID , tower);
    //    }


    //    return tower as T;
    //}

    public void RemoveTower(GameObject targetTower)
    {
        if (targetTower == null)
            return;

        long uid = targetTower.GetComponent<TestTowerBase>().UID;

        _liveTowerList.Remove(uid);
        _liveTowerInfoList.Remove(uid);
        SimpleObjectPool.Recycle(targetTower);
    }
    
    public GameObject GetFirstTower()
    {
        GameObject temp = null;

        foreach(var a in _liveTowerList)
        {
            temp = a.Value;
            break;
        }

        return temp;        
    }   



    private long GetNextUID()
    {
        return _nextUID++;
    }


}
