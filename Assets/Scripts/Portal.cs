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
    [SerializeField] private Material keyMaterial;
    [SerializeField] private KeyColor color;
    [SerializeField] private float rangeToOpen = 2f;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        renderSurface.GetComponent<Renderer>().material = material;
        otherPortal.myCamera.targetTexture = displayTexture;

        key.GetComponent<Renderer>().material = keyMaterial;
        door.GetComponent<Renderer>().material = keyMaterial;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CanOpen() && HasKey())
        {
            animator.SetTrigger("open");
            GameManager.Instantion.keys[color]--;
        }
    }

    public Transform GetOtherPortal()
    {
        return otherPortal.transform;
    }

    private bool CanOpen()
    {
        return Vector3.Distance(transform.position,
            GameObject.FindGameObjectWithTag("Player").transform.position) < rangeToOpen;
    }

    private bool HasKey()
    {
        return GameManager.Instantion.keys[color] > 0; 
    }

}
