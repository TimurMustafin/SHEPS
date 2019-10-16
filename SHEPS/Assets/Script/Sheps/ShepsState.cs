using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShepsState : MonoBehaviour
{
    private static bool walkState;
    private static bool runState;
    private static bool fireState;
    private static bool dyingState;

    public static bool WalkState { get => walkState; set => walkState = value; }
    public static bool RunState { get => runState; set => runState = value; }
    public static bool FireState { get => fireState; set => fireState = value; }
    public static bool DyingState { get => dyingState; set => dyingState = value; }
}
