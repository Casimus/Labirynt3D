using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{

    public Transform player;
    public Transform receiver;
    
    private bool playerIsOverlapping = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        receiver = transform.parent.GetComponent<Portal>().GetOtherPortal();
    }

    void FixedUpdate()
    {
        if (playerIsOverlapping)
        {
            playerIsOverlapping = false;
            player.transform.position = receiver.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        

        if (playerIsOverlapping) return;
        Debug.Log(other.tag);
        playerIsOverlapping = true;
       
    }

    void OnTriggerExit(Collider other)
    {
        playerIsOverlapping = false;
    }
}
