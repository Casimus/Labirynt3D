using UnityEngine;
public class Freez : PickUp
{
    [SerializeField] private int freezTime = 10;
    public override void Picked()
    {
        GameManager.Instantion.FreezTime(freezTime);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
}