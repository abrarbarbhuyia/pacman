using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingMusicManager : MonoBehaviour
{
    AudioSource introMusicSource;
    AudioSource normalStateMusicSource;
    public AudioClip normalStateMusic;
    bool isPlayingNormalState;
    // Start is called before the first frame update
    void Start()
    {
        introMusicSource = GetComponent<AudioSource>();
        normalStateMusicSource = gameObject.AddComponent<AudioSource>();
        isPlayingNormalState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!introMusicSource.isPlaying && !isPlayingNormalState) {
            normalStateMusicSource.clip = normalStateMusic;
            normalStateMusicSource.Play();
            normalStateMusicSource.volume = 0.33f;
            normalStateMusicSource.loop = true;
            isPlayingNormalState = true;
        }
    }
}
