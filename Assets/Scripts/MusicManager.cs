using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance {  get; private set; }

    void Awake()
    {
        if (Instance != null) return;
        Instance = this;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            GetComponent<AudioSource>().mute = !GetComponent<AudioSource>().mute;
        }
    }
}
