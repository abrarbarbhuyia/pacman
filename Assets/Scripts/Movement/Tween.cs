using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween
{
    public Transform Target { get; private set; }
    public Vector3 StartPos { get; private set; }
    public Vector3 EndPos { get; private set; }
    public float StartTime { get; private set; }
    public float Duration { get; private set; }

    public Tween(Transform setTarget, Vector3 setStartPos, Vector3 setEndPos, float setStartTime, float setDuration)
    {
        Target = setTarget;
        StartPos = setStartPos;
        EndPos = setEndPos;
        StartTime = setStartTime;
        Duration = setDuration;
    }
}
