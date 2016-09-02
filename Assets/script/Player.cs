using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {

    public float MoveSpeed;
    public float MoveSpeedX;
    
    public GameObject World;
    public float speedFallof;
    public float xSpeedFallof;
    private float XSpeedFallof;
    private levelGenerator world;
    
    private CharacterController characterController;
    private Vector3 Speed;
    private float xspeed;
    private float yspeed;
    private bool isMovingLeftRight;

    void Start()
    {
        world = World.GetComponent<levelGenerator>();       
        characterController = gameObject.GetComponent<CharacterController>();
        Speed = new Vector3(0, 0, MoveSpeed);
    }
    
    void FixedUpdate()
    {
        if(!MathStuff.IsBetween<float>(xspeed,-speedFallof,speedFallof))
        {
            XSpeedFallof += XSpeedFallof;
            if (xspeed < 0) xspeed += XSpeedFallof;
            else xspeed -= XSpeedFallof;
        }
        else
        {
            XSpeedFallof = xSpeedFallof;
            xspeed = 0;
            isMovingLeftRight = false;
        }
        Speed = new Vector3(xspeed,yspeed,MoveSpeed);
        characterController.SimpleMove(Speed);
    }



    public void MoveRight()
    {
        if (!isMovingLeftRight)
        {
            xspeed = MoveSpeedX;
            isMovingLeftRight = true;
        }
    }

    public void MoveLeft()
    {
        if (!isMovingLeftRight)
        {
            xspeed = -MoveSpeedX;
            isMovingLeftRight = true;
        }
    }

    public void Jump()
    {

    }

}
