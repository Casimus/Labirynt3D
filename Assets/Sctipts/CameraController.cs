using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensivity = 100f;
    private Transform playerBody;

    private float xRotation = 0;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform.parent;
    }

    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
                                                                // odwrocenie osi
        xRotation += mouseY * Time.deltaTime * mouseSensivity * -1;
        
        xRotation = Mathf.Clamp(xRotation, -90f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0); // obracam tylko kamerê
        playerBody.Rotate(Vector3.up * mouseX * mouseSensivity * Time.deltaTime); // obracam postaæ
    }
}
