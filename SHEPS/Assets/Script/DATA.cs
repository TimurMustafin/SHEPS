using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "Data")]
public class DATA : ScriptableObject
{
    public float speedPlayer;

    public Vector3 CameraOffset;
    public Vector3 CameraRotation;
    public float CameraDamp;

}
