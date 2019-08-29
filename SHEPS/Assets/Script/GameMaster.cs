using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public Camera cameraOne;
    public Camera cameraTow;
    bool  switcher;
   

    void Start()
    {
        switcher = true;
		cameraOne.enabled = true;
        cameraTow.enabled = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
			Debug.Log("SWITCH!!!");
            switcher = !switcher;
			SwitchCamera(switcher);

		}
        
    }

    void SwitchCamera(bool one)
	{
		cameraOne.enabled = one;
        cameraOne.GetComponent<AudioListener>().enabled = one;
		cameraTow.enabled = !one;
        cameraTow.GetComponent<AudioListener>().enabled = !one;
    }
}
