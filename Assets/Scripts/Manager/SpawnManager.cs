using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    private List<Tower> _towerList = new List<Tower>();

    public Tower BuildTower<T>(Tower tower, int index) where T : TowerBase, new()
    {
        tower.TowerBase = new T();
        tower.TowerBase.Init(index);
        tower.Init();

        _towerList.Add(tower);
        return tower;
    }

    public void DestroyTower(Tower tower)
    {
        if (tower == null) return;

        _towerList.Remove(tower);
        Destroy(tower.gameObject);
    }

    public Tower GetTower<T>() where T : TowerBase
    {
        var tower = _towerList.Find((c) => c.TowerBase is T);

        return tower;
    }

}
