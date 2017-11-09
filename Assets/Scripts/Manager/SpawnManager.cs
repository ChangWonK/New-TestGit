using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    private List<GameObject> _towerList = new List<GameObject>();
    private List<GameObject> _enemyList = new List<GameObject>();

    public Tower CreateTower<T>(GameObject towerPrefab, int index, Transform parent) where T : TowerBase, new()
    {
        towerPrefab = SimpleObjectPool.SpawnPoolObject(towerPrefab, Vector3.zero, Quaternion.identity, parent);

        Tower tower = towerPrefab.GetComponent<Tower>();

        tower.TowerBase = new T();
        tower.TowerBase.Init(index);
        tower.Init();

        _towerList.Add(towerPrefab);
        return tower;
    }

    public void RemoveTower(GameObject towerPrefab)
    {
        if (towerPrefab == null) return;

        towerPrefab.Recycle();
        _towerList.Remove(towerPrefab);
    }

    public Tower GetTower<T>() where T : TowerBase
    {
        var towerObject = _towerList.Find((c) => c.GetComponent<Tower>().TowerBase is T);

        if (towerObject == null) return null;

        return towerObject.GetComponent<Tower>();
    }

}
