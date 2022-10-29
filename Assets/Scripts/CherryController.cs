using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    private float elapsedTime;
    public GameObject cherryPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 10)
        {
            elapsedTime = 0;
            float x = -50;
            int y = Random.Range(-11, 21);
            var temp = Instantiate(cherryPrefab, new Vector3(x, y, 0), Quaternion.identity);
            // lerp the cherry to x = 15
            StartCoroutine(LerpCherry(temp, x, (float)y));
            
        }

    }

    // ienumerator to lerp temp object to x = 15 and y so that it passes through the centre
    IEnumerator LerpCherry(GameObject temp, float x, float y)
    {
        float elapsedTime = 0;
        // take 5 seconds to cross the screen
        float time = 6.5f;
        // setting y value based on where the other y value is, to make it cross the centre
        float yValue = 0;
        if (y == 21)
        {
            yValue = -11;
        }
        else if (y == 20)
        {
            yValue = -10;
        }
        else if (y == 19)
        {
            yValue = -9;
        }
        else if (y == 18)
        {
            yValue = -8;
        }
        else if (y == 17)
        {
            yValue = -7;
        }
        else if (y == 16)
        {
            yValue = -6;
        }
        else if (y == 15)
        {
            yValue = -5;
        }
        else if (y == 14)
        {
            yValue = -4;
        }
        else if (y == 13)
        {
            yValue = -3;
        }
        else if (y == 12)
        {
            yValue = -2;
        }
        else if (y == 11)
        {
            yValue = -1;
        }
        else if (y == 10)
        {
            yValue = 0;
        }
        else if (y == 9)
        {
            yValue = 1;
        }
        else if (y == 8)
        {
            yValue = 2;
        }
        else if (y == 7)
        {
            yValue = 3;
        }
        else if (y == 6)
        {
            yValue = 4;
        }
        else if (y == 3) {
            yValue = 7;
        }
        else if (y == 2)
        {
            yValue = 8;
        }
        else if (y == 1)
        {
            yValue = 9;
        }
        else if (y == 0)
        {
            yValue = 10;
        }
        else if (y == -1)
        {
            yValue = 11;
        }
        else if (y == -2)
        {
            yValue = 12;
        }
        else if (y == -3)
        {
            yValue = 13;
        }
        else if (y == -4)
        {
            yValue = 14;
        }
        else if (y == -5)
        {
            yValue = 15;
        }
        else if (y == -6)
        {
            yValue = 16;
        }
        else if (y == -7)
        {
            yValue = 17;
        }
        else if (y == -8)
        {
            yValue = 18;
        }
        else if (y == -9)
        {
            yValue = 19;
        }
        else if (y == -10)
        {
            yValue = 20;
        }
        else if (y == -11)
        {
            yValue = 21;
        }



        while (elapsedTime < time)
        {
            temp.transform.position = Vector3.Lerp(new Vector3(x, y, 0), new Vector3(9, yValue, 0), (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(temp);
    }

}
