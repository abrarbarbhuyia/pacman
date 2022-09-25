using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManAnimationManager : MonoBehaviour
{
    public Animator pacStudentController;
    public bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        if (isMoving == false)
        {
            StartCoroutine(Phases());
        }
        else {
            StartCoroutine(MovingPhases());
        }
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

    IEnumerator MovingPhases() {
        Vector3 flip = transform.localScale;
        flip.Set(-1, 1, 1);
        Vector3 original = transform.localScale;
        original.Set(1, 1, 1);
        gameObject.transform.Rotate(0.0f, 0.0f, 90.0f);
        yield return new WaitForSeconds(1.2f);
        gameObject.transform.Rotate(0.0f, 0.0f, -90.0f);
        gameObject.transform.localScale = flip;
        yield return new WaitForSeconds(1.3f);
        gameObject.transform.localScale = original;
        gameObject.transform.Rotate(0.0f, 0.0f, 90.0f);
        yield return new WaitForSeconds(1.4f);
        gameObject.transform.Rotate(0.0f, 0.0f, -90.0f);
        yield return new WaitForSeconds(2.2f);
        gameObject.transform.Rotate(0.0f, 0.0f, -90.0f);
        yield return new WaitForSeconds(0.8f);
        gameObject.transform.Rotate(0.0f, 0.0f, 90.0f);
        gameObject.transform.localScale = flip;
        yield return new WaitForSeconds(0.6f);
        gameObject.transform.localScale = original;
        gameObject.transform.Rotate(0.0f, 0.0f, -90.0f);
        yield return new WaitForSeconds(0.6f);
        gameObject.transform.Rotate(0.0f, 0.0f, 90.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
