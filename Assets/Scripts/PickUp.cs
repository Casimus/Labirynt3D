using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    public virtual void Picked()
    {
        //Debug.Log("Picked up");
        Destroy(this.gameObject);
    }

    public void Rotation()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime );
    }
}
