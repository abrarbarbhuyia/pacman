using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tweener : MonoBehaviour
{
    // private Tween activeTween;
    private List<Tween> activeTweens = new List<Tween>();
    public Vector3 currentPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < activeTweens.Count; i++)
        {
            if (TweenExists(activeTweens[i].Target) && activeTweens[i] != null && Vector3.Distance(activeTweens[i].Target.position, activeTweens[i].EndPos) > 0.1f)
            {
                float elapsedTime = (float)Time.time - activeTweens[i].StartTime;
                float t = elapsedTime / activeTweens[i].Duration;
                activeTweens[i].Target.position = Vector3.Lerp(activeTweens[i].StartPos, activeTweens[i].EndPos, t);
            }
            else if (TweenExists(activeTweens[i].Target))
            {
                activeTweens[i].Target.position = activeTweens[i].EndPos;
                activeTweens.Remove(activeTweens[i]);
            }
        }
    }

    public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        activeTweens.Add(new Tween(targetObject, startPos, endPos, Time.time, duration));
        return true;
    }

    public bool TweenExists(Transform target)
    {
        for (int i = 0; i < activeTweens.Count; i++)
        {
            if (activeTweens[i].Target.transform == target.transform)
            {
                return true;
            }
        }
        return false;
    }
}
