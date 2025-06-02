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
        GameManager.Instantion.AddKey(color);
        Destroy(this.gameObject);
    }
    void Update()
    {
        Rotation();
    }
}