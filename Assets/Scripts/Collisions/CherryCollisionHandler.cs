using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CherryCollisionHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        // get scoretext object from hud
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PacStudent"))
        {
            scoreText.text = (int.Parse(scoreText.text) + 100).ToString();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PacStudent"))
        {
            if (gameObject != null) {
                Destroy(gameObject);
            }
        }
    }
}
