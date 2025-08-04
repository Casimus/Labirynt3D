using UnityEngine;

public class Crystal : PickUp
{
    [SerializeField] private int points = 5;
    public override void Picked()
    {
        base.Picked();
        GameManager.Instantion.AddPoints(points);
        
    }
    void Update()
    {
        Rotation();
    }
}