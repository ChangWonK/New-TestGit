using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SimpleObjectPool : MonoBehaviour
{

    [Serializable]
    public class PrefabPools
    {
        public GameObject prefab;
        public int size;
    }


    public PrefabPools[] objectArray;


    // 내가 현재 가지고 있는 Object Pool
    private Dictionary<GameObject, List<GameObject>> poolObjects = new Dictionary<GameObject, List<GameObject>>();

    // 소환되서 현재 밖에 나와있는 오브젝트 관리하는 자료구조
    private Dictionary<GameObject, GameObject> spawnObjectlist = new Dictionary<GameObject, GameObject>();

    private static SimpleObjectPool instance;

    public static SimpleObjectPool Instacne
    {
        get
        {
            if(instance == null)
                Initialize();

            return instance;
        }
    }  

    void Start()
    {
        transform.position = new Vector3(0,0,0);
        transform.rotation = Quaternion.identity;
    }

    static private void Initialize()
    {
        instance = FindObjectOfType<SimpleObjectPool>();

        if (instance == null)
        {
            GameObject temp = new GameObject("SimpleObjectPool");
            instance = temp.AddComponent<SimpleObjectPool>();
<<<<<<< HEAD
        }

        instance.CreatePool();
    }

    private void CreatePool()
    {
        for (int i = 0; i < objectArray.Length; i++)
        {
            List<GameObject> temp;

            if(poolObjects.TryGetValue(objectArray[i].prefab, out temp) == false)
            {
                temp = new List<GameObject>();

                instance.poolObjects.Add(objectArray[i].prefab, temp);

                while(temp.Count < objectArray[i].size)
                {
                    GameObject obj = Instantiate(objectArray[i].prefab) as GameObject;
                    obj.transform.SetParent(instance.transform, false);
                    temp.Add(obj);
                    obj.SetActive(false);
                }

            }
        }
    }
 
=======
        }

        instance.CreateStartUpPools();
    }

    private void CreateStartUpPools()
    {
        if (objectList == null)
            return;

        for (int i = 0; i < objectList.Length; i++)
        {
            List<GameObject> temp;

            if (!poolObjects.TryGetValue(objectList[i].prefab, out temp)) // 만약 오브젝트 풀에 없으면 
            {
                temp = new List<GameObject>();

                instance.poolObjects.Add(objectList[i].prefab, temp);

                while (temp.Count < objectList[i].size)
                {
                    GameObject obj = Instantiate(objectList[i].prefab) as GameObject;
                    obj.transform.SetParent(instance.transform, false);
                    temp.Add(obj);

                    obj.SetActive(false);
                }
            }
        }
    }

>>>>>>> 60083e04c6c8431a1fd7006c6a20625bfc4800c7
    /// <summary>
    ///     /// 
    /// </summary>
    /// <param name="prefab"> Resources.Load 된 키값 </param>
    /// <param name="summonPos"></param>
    /// <param name="summonQuat"></param>
    /// <returns></returns>
    public static GameObject SpawnPoolObject(GameObject prefab, Vector3 summonPos, Quaternion summonQuat)
    {
        if (instance == null)
            Initialize();

        List<GameObject> remainPool;
        GameObject obj = null;
        Transform trans;

        if (instance.poolObjects.TryGetValue(prefab, out remainPool))
        {
            obj = null;

            if (remainPool.Count > 0)
            {
                while (obj == null && remainPool.Count > 0)
                {
                    obj = remainPool[0];
                    remainPool.RemoveAt(0);
                }
            }


            if (obj != null)  //  풀에 오브젝트가 있으면  꺼내온거 
            {
                trans = obj.transform;
                trans.position = summonPos;
                trans.rotation = summonQuat;
                trans.SetParent(null,false);
                obj.SetActive(true);

                Instacne.spawnObjectlist.Add(obj, prefab);

                return obj;
            }

            obj = Instantiate(prefab) as GameObject;
            trans = obj.transform;
            trans.SetParent(null,false);
            trans.position = summonPos;
            trans.rotation = summonQuat;

            Instacne.spawnObjectlist.Add(obj, prefab);

            return obj;

        }
        else // 만약 풀에 없는 오브젝트면 
        {
            obj = Instantiate(prefab) as GameObject;
            trans = obj.transform;
            trans.SetParent(null,false);
            trans.position = summonPos;
            trans.rotation = summonQuat;

            // 여기서 추가 생기는 것은 그냥 삭제시켜버린다  관리용품이 아니니까  

            return obj;
        }
    }

    public void WaitRecycle(GameObject obj, float seconds)
    {
        StartCoroutine(CoroutineWaitRecycle(obj,seconds));
    }

    private IEnumerator CoroutineWaitRecycle(GameObject obj, float seconds)
    {
        yield return new WaitForSeconds(seconds);

        Recycle(obj);
    }

    public static void Recycle(GameObject obj)
    {
        GameObject prefab;


        if (Instacne.spawnObjectlist.TryGetValue(obj, out prefab))
        {
            Instacne.poolObjects[prefab].Add(obj);
            Instacne.spawnObjectlist.Remove(obj);
            obj.transform.SetParent(instance.transform, false);
            obj.SetActive(false);

            return;
        }
        else //  풀 관리 용품이 아니면 ? 
        {
            Destroy(obj);
        }
    }

    public void Clear()
    {
        instance = null;        
    }
}

public static class ObjectPoolExtensions
{
    public static GameObject SpwanObject<T>(this T obj, Vector3 pos, Quaternion quat) where T : Component
    {
        return SimpleObjectPool.SpawnPoolObject(obj.gameObject, pos, quat);
    }


    public static void Recycle(this GameObject obj)
    {
        SimpleObjectPool.Recycle(obj);
    }

    public static void WaitRecycle(this GameObject obj, float seconds)
    {
        SimpleObjectPool.Instacne.WaitRecycle(obj , seconds);
    }
}


