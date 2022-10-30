using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentTeleporter : MonoBehaviour
{
    private GameObject currTeleport;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // as soon as the player enters the teleporter, the player is teleported to the other teleporter
        if (currTeleport != null)
        {
            transform.position = currTeleport.GetComponent<Teleport>().destinationTeleport.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter Left") || collision.CompareTag("Teleporter Right")) {
            currTeleport = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter Left") || collision.CompareTag("Teleporter Right"))
        {
            if (collision.gameObject == currTeleport) {
                currTeleport = null;
            }
        }
    }
}
