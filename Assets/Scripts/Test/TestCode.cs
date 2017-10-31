using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{

    public List<GameObject> _outPool = new List<GameObject>();

	void Start ()
    {
		
	}
    
	
	void OnGUI()
    {


        if(GUI.Button(new Rect(0,0,100,100), "Instansite"))
        {
            var effect = ObjectPool.i.SpwanObject();

            if(effect)
            {
                effect.transform.position = Vector3.zero;
                _outPool.Add(effect);
            }
        }


        if (GUI.Button(new Rect(0, 200, 100, 100), "SpwaPool"))
        {
            GameObject obj = null;

            if (_outPool.Count > 0)
            {
                obj = _outPool[0];
                _outPool.RemoveAt(0);
            }

            ObjectPool.i.Recycle(obj);
        }

    }
}
