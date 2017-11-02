using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoSingleton<ObjectPool>
{
    public List<ObjectPooled> ObjectPoolList = new List<ObjectPooled>();

    void Awake()
    {
        for (int i = 0; i < ObjectPoolList.Count; i++)
        {
            ObjectPoolList[i].Init(transform);
        }
    }

    public bool PushToPool(string itemName, GameObject item, Transform parent = null)
    {
        ObjectPooled pool = GetPoolItem(itemName);
        if (pool == null) return false;

        pool.PushToPool(item, parent == null ? transform : parent);
        return true;
     }

    public GameObject PopFromPool(string itemName, Transform parent = null)
    {
        ObjectPooled pool = GetPoolItem(itemName);
        if (pool == null) return null;

        return pool.PullFromPool(parent);
    }

    ObjectPooled GetPoolItem(string itemName)
    {
        for (int i = 0; i < ObjectPoolList.Count; i++)
        {
            if (ObjectPoolList[i].PoolItemName ==itemName)
                return ObjectPoolList[i];
        }

        Debug.Log("no poolList");
        return null;
    }

	
	
		
}

//   public GameObject[] EffectObjectPool;

//   private List<GameObject> _poolObject = new List<GameObject>();


//void Start ()
//   {
//       for (int i = 0; i < EffectObjectPool.Length; i++)
//       {
//           var obj = Instantiate(EffectObjectPool[i]);
//           obj.SetActive(false);

//           obj.transform.SetParent(transform);
//           _poolObject.Add(obj);

//       }
//   }	

//   public GameObject SpwanObject()
//   {

//       var obj = _poolObject.Find(x => x.activeSelf == false);

//       if (obj)
//       {
//           obj.transform.SetParent(null);
//           obj.SetActive(true);

//           _poolObject.Remove(obj);

//           return obj;
//       }
//       else
//           return null;
//   }

//   public void Recycle(GameObject obj)
//   {
//       if (obj == null)
//           return;

//       obj.SetActive(false);
//       obj.transform.SetParent(transform);
//       _poolObject.Add(obj);
//   }