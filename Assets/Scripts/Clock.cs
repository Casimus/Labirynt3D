using UnityEngine;
public class Clock : PickUp
{
    [SerializeField]
    private int time = 5;
    public override void Picked()
    {
        base.Picked();
        GameManager.Instantion.AddTime(time);
        
    }
    void Update()
    {
        Rotation();
    }
}