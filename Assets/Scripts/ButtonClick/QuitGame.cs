using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // When button is clicked, quit the game.
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game quit");
    }
}
