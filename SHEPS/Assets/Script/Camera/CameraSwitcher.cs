using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera cameraOne;
    public Camera cameraTow;
    bool switcher;

    void Start()
    {
        switcher = true;
        cameraOne.enabled = true;
        cameraTow.enabled = false;

    }
   
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {            
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
