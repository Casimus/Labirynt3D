using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float speed = 12f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Vector3 velocity; 
    CharacterController characterController;

    // odniesienie do komponentu w Awake bo komponent i skrypt s¹ w tym samym obiekcie
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveSpeed = SetSpeed();

        PlayerMove(moveSpeed);
    }

    private float SetSpeed()
    {
        Ray ray = new Ray(groundCheck.position, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, 0.1f, groundLayer))
        {
            switch(hit.collider.gameObject.tag)
            {
                case "Slow":
                    return this.speed / 2 ;
                case "Fast":
                    return this.speed * 2 ;
                default:
                    return this.speed;
            }
        }
        return this.speed;
    }

    private void PlayerMove(float speed)
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z).normalized * speed * Time.deltaTime;
        characterController.Move(move);
    }

    public Transform GetGroundCheck() => groundCheck;
    public LayerMask GetGroundLayer() => groundLayer;
 
}
