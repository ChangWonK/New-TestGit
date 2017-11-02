using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public string PoolItemName = "HumanBullet";
    private float LifeTime = 4f;
    private float _elapsedTime = 0;

    void Update()
    {
        if(GetTimer() > LifeTime)
        {
            SetTimer();
            ObjectPool.i.PushToPool(PoolItemName, gameObject);
        }
    }


    private float GetTimer()
    {
        return (_elapsedTime += Time.deltaTime);
    }

    private void SetTimer()
    {
        _elapsedTime = 0f;
    }
}
