using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PacStudentAudioManager : MonoBehaviour
{
    public PacStudentController pacStudentController;
    public AudioSource audioSource;
    public AudioClip walkSound;
    public AudioClip eatSound;
    public bool isChanged = false;
    public bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.volume = 0.5f;
        audioSource.pitch = 1f;
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCurrentFood() && audioSource.clip == walkSound && isPlaying == true)
        {
            StopCoroutine("SwitchAudioClip(walkSound)");
        }
        else if (!isCurrentFood() && audioSource.clip == eatSound && isPlaying == true)
        {
            StopCoroutine("SwitchAudioClip(eatSound)");
        }

        if (pacStudentController.isMoving == false && isPlaying == true)
        {
            audioSource.Stop();
        }
        if (pacStudentController.isMoving == true && isFood() == true && isPlaying == false)
        {
            audioSource.pitch = 3f;
            StartCoroutine(SwitchAudioClip(eatSound));
        }
        if (pacStudentController.isMoving == true && isFood() == false && isPlaying == false)
        {
            audioSource.pitch = 1f;
            StartCoroutine(SwitchAudioClip(walkSound));
        }


    }

    IEnumerator SwitchAudioClip(AudioClip clip)
    {
        isPlaying = true;
        audioSource.clip = clip;
        audioSource.Play();
        yield return new WaitForSeconds(clip.length);
        isPlaying = false;
    }

    private bool isCurrentFood() {
        if (pacStudentController.map.GetTile(pacStudentController.map.WorldToCell(pacStudentController.gameObject.transform.position)) == null) {
            return false;
        }
        

        if (pacStudentController.map.GetTile(pacStudentController.map.WorldToCell(pacStudentController.gameObject.transform.position)).name == "5"
            || pacStudentController.map.GetTile(pacStudentController.map.WorldToCell(pacStudentController.gameObject.transform.position)).name == "6")
        {
            return true;
        }
        else 
        {
            return false;
        }
        
    }

    private bool isFood() {
        Vector3 currentDirection = pacStudentController.getCurrentDirection();
        TileBase nextTile = pacStudentController.map.GetTile(pacStudentController.map.WorldToCell(pacStudentController.gameObject.transform.position + currentDirection));
        if (nextTile == null)
        {
            return false;
        }
        if (nextTile.name == "5" || nextTile.name == "6")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
