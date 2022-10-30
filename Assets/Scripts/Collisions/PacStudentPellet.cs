using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PacStudentPellet : MonoBehaviour
{
    public Tilemap path;
    private bool isEating;
    public TextMeshProUGUI scoreText;
    public int lastPellets = 217;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEating == true)
        {
            path.SetTile(path.WorldToCell(transform.position), null);
            int count = 0;
            foreach (var tile in path.cellBounds.allPositionsWithin)
            {
                if (path.HasTile(tile))
                {
                    count++;
                }
            }

            int.TryParse(scoreText.text, out int score);
            score = score + (lastPellets - count) * 10;
            lastPellets = count;
            scoreText.text = score.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pellet"))
        {
            isEating = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pellet"))
        {
            isEating = false;
        }
    }
}
