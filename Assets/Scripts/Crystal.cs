using UnityEngine;

public class Crystal : PickUp
{
    [SerializeField] private int points = 5;
    public override void Picked()
    {
        GameManager.Instantion.AddPoints(points);
        Destroy(this.gameObject);
    }
    void Update()
    {
        Rotation();
    }
}