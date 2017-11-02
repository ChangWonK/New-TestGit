
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPooled
{
    public string PoolItemName = string.Empty;
    public GameObject Prefab = null;
    public int PoolCount = 0;

    [SerializeField]
    private List<GameObject> _poolList = new List<GameObject>();

    public void Init(Transform parent = null)
    {
        for (int i = 0; i < PoolCount; i++)
        {
            _poolList.Add(CreateItem(parent));
        }
    }

    public void PushToPool(GameObject item, Transform parent = null)
    {
        item.transform.SetParent(parent);
        item.SetActive(false);
        _poolList.Add(item);
    }

    public GameObject PullFromPool(Transform parent = null)
    {
        if (_poolList.Count == 0) return null;
            //_poolList.Add(CreateItem(parent));

        GameObject item = _poolList[0];
        _poolList.RemoveAt(0);

        return item;
    }

    private GameObject CreateItem(Transform parent = null)
    {
        GameObject item = Object.Instantiate(Prefab) as GameObject;
        item.name = PoolItemName;
        item.transform.SetParent(parent);
        item.SetActive(false);

        return item;
    }


}
