using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentAnimManager : MonoBehaviour
{
    public PacStudentController pacStudentController;
    public Animator pacStudentAnimator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pacStudentController.isMoving == false)
        {
            pacStudentAnimator.speed = 0;
        }
        else
        {
            pacStudentAnimator.speed = 1;
        }

        //  set pacstudents rotation based on currentdirection
        Vector3 currentDirection = pacStudentController.getCurrentDirection();
        if (currentDirection == Vector3.up)
        {
            Quaternion temp = Quaternion.Euler(0, 0, 90);
            gameObject.transform.rotation = temp;
        }
        if (currentDirection == Vector3.down)
        {
            Quaternion temp = Quaternion.Euler(0, 0, -90);
            gameObject.transform.rotation = temp;
        }
        if (currentDirection == Vector3.left)
        {
            // set scale of x to be -1
            Quaternion temp = Quaternion.Euler(0, 180, 0);
            gameObject.transform.rotation = temp;
        }
        if (currentDirection == Vector3.right)
        {
            Quaternion temp = Quaternion.Euler(0, 0, 0);
            gameObject.transform.rotation = temp;
        }
        else
        {

        }
    }
}
