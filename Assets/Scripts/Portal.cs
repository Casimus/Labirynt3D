using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Portal otherPortal;
    [SerializeField] Material material;
    [SerializeField] RenderTexture displayTexture;
    [SerializeField] float openRange = 2f;
    [SerializeField] KeyColor color;
    [SerializeField] GameObject door;

    public Camera myCamera;

    public Transform renderSurface;
    public Transform portalCollider;

    private GameObject player;
    private bool isOpen = false;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();

    }


    void Start()
    {
        renderSurface.GetComponent<Renderer>().material = material;
        otherPortal.myCamera.targetTexture = displayTexture;
        player = GameObject.FindWithTag("Player");

        portalCollider.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isOpen) return;

        if (Input.GetKeyDown(KeyCode.E) && IsInRange() && CanOpen())
        {
            OpenPortal();

        }
    }

    private void OpenPortal()
    {
        // uruchom animacje
        animator.SetTrigger("open");
        if (color == KeyColor.Red)
        {
            GameManager.Instantion.redKey--;
        }
        else if (color == KeyColor.Green)
        {
            GameManager.Instantion.greenKey--;
        }
        else if (color == KeyColor.Gold)
        {
            GameManager.Instantion.goldKey--;
        }
        portalCollider.gameObject.SetActive(true);
        door.SetActive(false);
    }

    private bool IsInRange()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log(distance);
        return distance <= openRange;
    }

    private bool CanOpen()
    {
        if (color == KeyColor.Red && GameManager.Instantion.redKey > 0 ||
            color == KeyColor.Green && GameManager.Instantion.greenKey > 0 ||
            color == KeyColor.Gold && GameManager.Instantion.greenKey > 0)
        {
            return true;
        }
        return false;
    }

    public Transform GetOtherPortal()
    {
        return otherPortal.transform;
    }




}
