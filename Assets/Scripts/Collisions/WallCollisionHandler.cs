using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public PacStudentController pacStudentController;
    public AudioClip wallClip;
    public AudioSource audioSource;
    public PacStudentAudioManager pacStudentAudioManager;
    public ParticleSystem wallHitParticle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(InstantiateParticleEffect());
        audioSource.pitch = 1f;
        audioSource.clip = wallClip;
        // stop switch clip coroutine
        if (pacStudentAudioManager.isPlaying == true)
        {
            StopCoroutine("SwitchAudioClip()");
        }
        StartCoroutine(PlayWallClip());
    }

    IEnumerator PlayWallClip()
    {
        audioSource.clip = wallClip;
        audioSource.Play();
        yield return new WaitForSeconds(wallClip.length);
    }

    IEnumerator InstantiateParticleEffect()
    {
        Instantiate(wallHitParticle, pacStudentController.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(wallHitParticle.main.duration);
    }
}
