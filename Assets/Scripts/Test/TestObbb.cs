using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObbb : MonoBehaviour
{
	
	void OnGUI ()
    {

        if(GUI.Button(new Rect(100,100,100,100), "Resources Load"))
        {
            GameObject temp = Resources.Load<GameObject>("TestCube");            

            var ttete = Instantiate(temp);

            Debug.Log(ttete.GetInstanceID());

        }
		
	}

}
