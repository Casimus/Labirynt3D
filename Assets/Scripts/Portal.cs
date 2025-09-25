using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Portal otherPortal;
    [SerializeField] Material material;
    [SerializeField] RenderTexture displayTexture;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject key;
    [SerializeField] private Material keyMaterial;
    [SerializeField] private KeyColor keyColor;
    [SerializeField] private float rangeToOpen = 4f;

    public Camera myCamera;

    public Transform renderSurface;
    public Transform portalCollider;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Start()
    {
        renderSurface.GetComponent<Renderer>().material = material;
        otherPortal.myCamera.targetTexture = displayTexture;
        door.GetComponent<Renderer>().material = keyMaterial;
        key.GetComponent<Renderer>().material = keyMaterial;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && CanOpen() )
        {
            animator.SetTrigger("open");
        }
    }

    public Transform GetOtherPortal()
    {
        return otherPortal.transform;
    }

    private bool CanOpen()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        return Vector3.Distance(playerPos, transform.position) < rangeToOpen;
    }


}
