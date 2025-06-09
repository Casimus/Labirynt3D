using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Portal otherPortal;
    [SerializeField] Material material;
    [SerializeField] RenderTexture displayTexture;

    public Camera myCamera;

    public Transform renderSurface;
    public Transform portalCollider;

    void Start()
    {
        renderSurface.GetComponent<Renderer>().material = material;
        otherPortal.myCamera.targetTexture = displayTexture;
    }

    public Transform GetOtherPortal()
    {
        return otherPortal.transform;
    }




}
