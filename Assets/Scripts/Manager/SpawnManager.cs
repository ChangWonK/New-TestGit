using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    private List<GameObject> _towerList = new List<GameObject>();
    private List<GameObject> _enemyList = new List<GameObject>();

    public T CreateTower<T>(GameObject towerPrefab, Vector3 pos, int index, Transform parent) where T : TowerBase
    {
        towerPrefab = SimpleObjectPool.SpawnPoolObject(towerPrefab, pos, Quaternion.identity, parent);

        T tower = towerPrefab.AddComponent<T>();
        tower.LocalIndex = index;
        _towerList.Add(towerPrefab);

        //Tower tower = towerPrefab.GetComponent<Tower>();

        //tower.TowerBase = new T();
        //tower.TowerBase.Init(index);
        //tower.Init();

        //_towerList.Add(towerPrefab);
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

    public EnemyBase CreateEnemy<T>(GameObject enemyPrefab, Vector3 pos, int index, Transform parent) where T : EnemyBase
    {
        enemyPrefab = SimpleObjectPool.SpawnPoolObject(enemyPrefab, pos, Quaternion.identity, parent);

        T enemy =  enemyPrefab.AddComponent<T>();
        enemy.Index = index;

        _enemyList.Add(enemyPrefab);
        return enemy;
    }

    public GameObject GetFirstEnemy()
    {
        if (_enemyList.Count < 1)
            return null;

        return _enemyList[0];
    }

    public List<GameObject> GetEnemyList()
    {
        return _enemyList;
    }

    public GameObject GetCloseEnemyList(Transform trans)
    {   
        float lastlegth = 0;
        int findIndex = 0;

        if (_enemyList.Count < 1) return null;
        for(int i = 0; i < _enemyList.Count; i++)
        {
            float length = Vector3.SqrMagnitude(_enemyList[i].transform.position - trans.position);

            if (i == 0)
            {
                lastlegth = length;
                findIndex = 0;
                continue;
            }

            if (length < lastlegth)
            {
                findIndex = i;
                lastlegth = length;
            }            
        }

        return _enemyList[findIndex];

    }




}
