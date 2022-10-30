using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerPelletCollisionHandler : MonoBehaviour
{
    public TextMeshProUGUI scaredText;
    public TextMeshProUGUI scaredTimer;
    private float elapsed;
    public bool isScared = false;
    // Start is called before the first frame update
    void Start()
    {
        scaredText = GameObject.Find("Ghost Timer Text").GetComponent<TextMeshProUGUI>();
        scaredTimer = GameObject.Find("Ghost Timer").GetComponent<TextMeshProUGUI>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsed >= 10f && isScared == true) {  
            isScared = false;
            SetUnfrightened();
            StopCoroutine(ChangeGhostTextColour());
            scaredText.color = new Color32(0, 0, 255, 0);
            scaredTimer.color = new Color32(0, 0, 255, 0);
            elapsed = 0;
        }

        if (elapsed > 0 && isScared == true)
        {
            scaredTimer.text = (10 - (int)elapsed).ToString();
        }

        elapsed += Time.deltaTime;

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Power Pellet"))
        {
            StopCoroutine(ChangeGhostTextColour());
            isScared = true;
            elapsed = 0;
            StartCoroutine(ChangeGhostTextColour());
            SetFrightened();            
            if (collision.gameObject != null)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    void SetFrightened()
    {
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        foreach (GameObject ghost in ghosts)
        {
            ghost.GetComponent<Animator>().SetBool("walkFinished", true);
        }
    }

    void SetUnfrightened()
    {
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        foreach (GameObject ghost in ghosts)
        {
            ghost.GetComponent<Animator>().SetBool("walkFinished", false);
        }
    }

    IEnumerator ChangeGhostTextColour()
    {
        scaredText.color = new Color32(0, 0, 255, 255);
        scaredTimer.color = new Color32(0, 0, 255, 255);
        yield return new WaitForSeconds(10f);
    }
}
