using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    public Transform target;
    public DATA data;

    Vector3 offset;
    Vector3 rotation;
    float damp;

    void Update()
    {
        offset = data.CameraOffset;
        rotation = data.CameraRotation;
        damp = data.CameraDamp;


        transform.position = Vector3.Lerp(transform.position, target.position + offset, damp * Time.deltaTime);
        transform.rotation = Quaternion.Euler(rotation);
    }
}
