using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Renderer model;

    public virtual void Picked()
    {
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip, 1);
        model.enabled = false;
        GetComponent<Collider>().enabled = false;
        Destroy(this.gameObject,1f);
    }

    public void Rotation()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime );
    }
}
