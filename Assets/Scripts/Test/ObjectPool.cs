using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoSingleton<ObjectPool>
{

    public GameObject[] EffectObjectPool;

    private List<GameObject> _poolObject = new List<GameObject>();


	void Start ()
    {
        for (int i = 0; i < EffectObjectPool.Length; i++)
        {
            var obj = Instantiate(EffectObjectPool[i]);
            obj.SetActive(false);

            obj.transform.SetParent(transform);
            _poolObject.Add(obj);
                
        }
    }	

    public GameObject SpwanObject()
    {

        var obj = _poolObject.Find(x => x.activeSelf == false);

        if (obj)
        {
            obj.transform.SetParent(null);
            obj.SetActive(true);

            _poolObject.Remove(obj);

            return obj;
        }
        else
            return null;
    }

    public void Recycle(GameObject obj)
    {
        if (obj == null)
            return;

        obj.SetActive(false);
        obj.transform.SetParent(transform);
        _poolObject.Add(obj);
    }

	
	
		
}
