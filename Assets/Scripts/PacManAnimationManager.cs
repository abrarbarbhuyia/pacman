using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManAnimationManager : MonoBehaviour
{
    public Animator pacStudentController;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(Phases());
    }

    IEnumerator Phases() {
        yield return new WaitForSeconds(3);
        gameObject.transform.Rotate(0.0f, 0.0f, 90.0f);
        yield return new WaitForSeconds(3);
        gameObject.transform.Rotate(0.0f, 0.0f, -90.0f);
        Vector3 flip = transform.localScale;
        flip.Set(-1, 1, 1);
        gameObject.transform.localScale = flip;
        yield return new WaitForSeconds(3);
        Vector3 original = transform.localScale;
        original.Set(1, 1, 1);
        gameObject.transform.localScale = original;
        gameObject.transform.Rotate(0.0f, 0.0f, -90.0f);
        yield return new WaitForSeconds(3);
        gameObject.transform.Rotate(0.0f, 0.0f, 90.0f);
        yield return new WaitForSeconds(3);
        pacStudentController.SetBool("walkFinished", true);
        yield return new WaitForSeconds(3);
    }

    // Update is called once per frame
    void Update()
    {

    }
}