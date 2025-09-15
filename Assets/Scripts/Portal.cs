using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Portal otherPortal;
    [SerializeField] Material material;
    [SerializeField] RenderTexture displayTexture;

    public Camera myCamera;

    public Transform renderSurface;
    public Transform portalCollider;

    [SerializeField] private GameObject key;
    [SerializeField] private GameObject door;
    [SerializeField] private Material keyColor;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        renderSurface.GetComponent<Renderer>().material = material;
        otherPortal.myCamera.targetTexture = displayTexture;

        key.GetComponent<Renderer>().material = keyColor;
        door.GetComponent<Renderer>().material = keyColor;
    }

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("open");
        }
    }

    public Transform GetOtherPortal()
    {
        return otherPortal.transform;
    }




}
