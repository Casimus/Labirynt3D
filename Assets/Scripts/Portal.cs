using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Portal otherPortal;
    [SerializeField] Material material;
    [SerializeField] RenderTexture displayTexture;
    [SerializeField] float openRange = 2f;

    public Camera myCamera;

    public Transform renderSurface;
    public Transform portalCollider;

    private GameObject player;
    private bool isOpen = false;

    void Start()
    {
        renderSurface.GetComponent<Renderer>().material = material;
        otherPortal.myCamera.targetTexture = displayTexture;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (isOpen) return;

        if (Input.GetKeyDown(KeyCode.E) && IsInRange() && CanOpen())
        {
            // uruchom animacje
            // odblokuj portal
        }
    }

    private bool IsInRange()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        return distance <= openRange;
    }

    private bool CanOpen()
    {
        return true;
    }

    public Transform GetOtherPortal()
    {
        return otherPortal.transform;
    }




}
