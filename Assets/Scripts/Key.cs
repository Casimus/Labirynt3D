using UnityEngine;
public enum KeyColor
{
    Red,
    Green,
    Gold
}

public class Key : PickUp
{
    [SerializeField] private KeyColor color;
    public override void Picked()
    {
        base.Picked();
        GameManager.Instantion.AddKey(color);
        
    }
    void Update()
    {
        Rotation();
    }
}