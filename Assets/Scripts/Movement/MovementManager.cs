using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField]
    public GameObject item;
    public Tweener tweener;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Phases());
    }

    // Update is called once per frame
    IEnumerator Phases()
    {
        tweener.AddTween(item.transform, new Vector3(-27.5f, 5, 0), new Vector3(-27.5f, 11f), 1.2f);
        yield return new WaitForSeconds(1.2f);
        tweener.AddTween(item.transform, new Vector3(-27.5f, 11f, 0), new Vector3(-32.5f, 11f), 1.3f);
        yield return new WaitForSeconds(1.3f);
        tweener.AddTween(item.transform, new Vector3(-32.5f, 11f, 0), new Vector3(-32.5f, 18.5f), 1.4f);
        yield return new WaitForSeconds(1.4f);
        tweener.AddTween(item.transform, new Vector3(-32.5f, 18.5f, 0), new Vector3(-21.5f, 18.5f), 2.2f);
        yield return new WaitForSeconds(2.2f);
        tweener.AddTween(item.transform, new Vector3(-21.5f, 18.5f, 0), new Vector3(-21.5f, 14f), 0.8f);
        yield return new WaitForSeconds(0.8f);
        tweener.AddTween(item.transform, new Vector3(-21.5f, 14f, 0), new Vector3(-24.5f, 14f), 0.6f);
        yield return new WaitForSeconds(0.6f);
        tweener.AddTween(item.transform, new Vector3(-24.5f, 14f, 0), new Vector3(-24.5f, 11f), 0.6f);
        yield return new WaitForSeconds(0.6f);
        tweener.AddTween(item.transform, new Vector3(-24.5f, 11f, 0), new Vector3(-21.5f, 11f), 0.6f);
        yield return new WaitForSeconds(0.6f);
        item.GetComponent<Animator>().enabled = false;
        item.GetComponent<AudioSource>().enabled = false;
    }
}
