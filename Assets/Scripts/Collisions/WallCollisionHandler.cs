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
        if (collision.CompareTag("PacStudent")) {
            Vector3Int tilePosition = pacStudentController.wallMap.WorldToCell(collision.transform.position);
            StartCoroutine(InstantiateParticleEffect(tilePosition));
            audioSource.pitch = 1f;
            audioSource.clip = wallClip;
            // stop switch clip coroutine
            if (pacStudentAudioManager.isPlaying == true)
            {
                StopCoroutine("SwitchAudioClip()");
            }
            StartCoroutine(PlayWallClip());
        }
    }

    IEnumerator PlayWallClip()
    {
        audioSource.clip = wallClip;
        audioSource.Play();
        yield return new WaitForSeconds(wallClip.length);
    }

    IEnumerator InstantiateParticleEffect(Vector3 tilePostition)
    {
        var temp = Instantiate(wallHitParticle, tilePostition, Quaternion.identity);
        yield return new WaitForSeconds(wallHitParticle.main.duration);
        Destroy(temp.gameObject);
    }
}
