using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

interface IUserInput 
{
    float Moving { get; }
    float Turning { get; }
    bool Toggle { get; }
    bool CutSpace { get; }

    event Action<bool> OnRunToggle;
    event Action OnFireToggle;
    event Action OnSoundBombToggle;

    void ReadInput();
}
