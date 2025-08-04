using UnityEngine;
public class Freez : PickUp
{
    [SerializeField] private int freezTime = 10;
    public override void Picked()
    {
        base.Picked();
        GameManager.Instantion.FreezTime(freezTime);
        
    }
    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
}