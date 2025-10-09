using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] songs;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    void Start()
    {
        int trackNo = Random.Range(0, songs.Length);
        
        _audioSource.clip = songs[trackNo];
        _audioSource.Play();
    }
}

