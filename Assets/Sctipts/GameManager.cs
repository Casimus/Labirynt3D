using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private float timeToEnd = 90f;
    void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
   
    void Update()
    {
        timeToEnd -= Time.deltaTime;
        Debug.Log(timeToEnd);
    }
}
