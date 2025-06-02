using UnityEngine;
public class Clock : PickUp
{
    [SerializeField]
    private int time = 5;
    public override void Picked()
    {
       
        GameManager.Instantion.AddTime(time);
        Destroy(this.gameObject);
    }
    void Update()
    {
        Rotation();
    }
}