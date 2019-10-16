using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixUserInput : MonoBehaviour, IUserInput
{
    public float Moving { get; private set; }
    public float Turning { get; private set; }
    public bool Toggle { get; private set; }
    public bool CutSpace { get; private set; }

    public event Action <bool> OnRunToggle;
    public event Action OnFireToggle;
    public event Action OnSoundBombToggle;

    public void ReadInput()
    {
        Moving = Mathf.Clamp(Input.GetAxis("Vertical"), 0f, 1f);
        Turning = Input.GetAxis("Mouse X");

        if (Input.GetKey(KeyCode.Mouse1))
            OnRunToggle(true);

        if (Input.GetKeyUp(KeyCode.Mouse1))
            OnRunToggle(false);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            OnFireToggle();

        if (Input.GetKeyDown(KeyCode.Space))
            OnSoundBombToggle();
    }
}
