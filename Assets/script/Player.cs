using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {

    public float MoveSpeed;
    public float MoveSpeedX;
    
    public GameObject World;
    public float pointAccuracy;
    private levelGenerator world;
    
    private CharacterController characterController;
    private Vector3 Speed;
    public float xspeed;
    private float yspeed;
    private bool canMove = true;

    public GameObject LPoint;
    public GameObject MPoint;
    public GameObject RPoint;
    private GameObject currPoint;

    void Start()
    {
        world = World.GetComponent<levelGenerator>();       
        characterController = gameObject.GetComponent<CharacterController>();
        Speed = new Vector3(0, 0, MoveSpeed);
        currPoint = MPoint;
    }
    
    void FixedUpdate()
    {
        Speed = new Vector3(xspeed,yspeed,MoveSpeed);
        characterController.SimpleMove(Speed);
        if (!MathStuff.IsBetween<float>(transform.position.x, currPoint.transform.position.x - pointAccuracy, currPoint.transform.position.x + pointAccuracy)) this.transform.position = Vector3.MoveTowards(transform.position, currPoint.transform.position, xspeed);
        else canMove = true;
    }



    public void MoveRight()
    {
        if (canMove)
        {
            if (currPoint == MPoint)
            {
                currPoint = RPoint;
                canMove = false;
            }
            else if (currPoint == LPoint)
            {
                currPoint = MPoint;
                canMove = false;
            }
        }
    }

    public void MoveLeft()
    {
        if (canMove)
        {
            if (currPoint == MPoint)
            {
                currPoint = LPoint;
                canMove = false;
            }
            else if (currPoint == RPoint)
            {
                currPoint = MPoint;
                canMove = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "killCollider") Die();

        if(collision.transform.tag == "Pickup")
        {
            GameObject.Destroy(collision.gameObject);
            print("REWORK PICKUP CODE, YOU DUNCE!");
        }

    }
    public void Jump()
    {

    }

    public void Die()
    {
        GameManager.Instance.ShowEndGameScreen();
    }
}
