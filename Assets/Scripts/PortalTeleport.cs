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
        if (playerIsOverlapping && Vector3.Dot(player.forward ,receiver.forward)>0.5)
        {
            playerIsOverlapping = false;
            player.transform.position = receiver.position;
            player.transform.rotation = receiver.rotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        if (playerIsOverlapping) return;

        Debug.Log(other.tag);
        playerIsOverlapping = true;
       
    }

    void OnTriggerExit(Collider other)
    {
        playerIsOverlapping = false;
    }
}
