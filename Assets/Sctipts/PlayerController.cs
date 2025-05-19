using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float speed = 12f;

    private Vector3 velocity; 
    CharacterController characterController;

    // odniesienie do komponentu w Awake bo komponent i skrypt s¹ w tym samym obiekcie
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right*x + transform.forward*z).normalized * speed * Time.deltaTime;
        characterController.Move(move);
    }
}
