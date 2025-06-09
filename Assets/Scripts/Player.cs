using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag != "PickUp") return;
        GameObject pickup = hit.collider.gameObject;
        if (!pickup.TryGetComponent(out PickUp pickUp)) return;
        pickUp.Picked();

        
    }
}