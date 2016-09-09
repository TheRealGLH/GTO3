﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {

    public float MoveSpeed;
    public float MoveSpeedX;
    
    public GameObject World;
    public float pointAccuracy;
    public float fieldOfView;
    private levelGenerator world;
    
    private CharacterController characterController;
    private Vector3 moveDirection;
    public float xspeed;
    private float yspeed;
    private bool canMove = true;

    public GameObject LPoint;
    public GameObject MPoint;
    public GameObject RPoint;
    private GameObject currPoint;
    private bool hasJumped = false;
    private bool canJump = true;
    private bool isAirborne;
    public float VVelocity;
    public float VTerminalVelocity;
    public float JumpSpeed;
    private float VSpeed;


    void Start()
    {
        world = World.GetComponent<levelGenerator>();       
        characterController = gameObject.GetComponent<CharacterController>();
        moveDirection = new Vector3(0, 0, MoveSpeed);
        currPoint = MPoint;
    }
    
    void FixedUpdate()
    {
        if (!GameManager.Instance.IsGamePaused())
        {
            moveDirection = new Vector3(0, 0, 1);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= MoveSpeed*0.05F;





            if (!MathStuff.IsBetween<float>(transform.position.x, currPoint.transform.position.x - pointAccuracy, currPoint.transform.position.x + pointAccuracy))
                this.transform.position = Vector3.MoveTowards(transform.position, currPoint.transform.position, xspeed);
            else canMove = true;
            float dist;
            GameObject p = world.GetLatestPiece();
            if (p != null)
            {
                dist = p.transform.position.z - transform.position.z;
                if (dist < fieldOfView)
                {
                    world.NextPiece();
                }
            }
            if(hasJumped&&!characterController.isGrounded)
            {
                VSpeed -= VVelocity;
            }
            else if(characterController.isGrounded)
            {
                VSpeed = 0;
                hasJumped = false;
            }
            if(VSpeed<=VTerminalVelocity) VSpeed = VTerminalVelocity;

            moveDirection.y = VSpeed;
            characterController.Move(moveDirection);


        }

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

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "killCollider") Die();

        if (collider.gameObject.tag == "Pickup")
        {
            
            Coin c = collider.gameObject.GetComponent<Coin>();
            if(c!= null)
            {
                GameManager.Instance.PickupCoin();
            }

            GameObject.Destroy(collider.gameObject);
            print("REWORK PICKUP CODE, YOU DUNCE!");
        }

    }
    public void Jump()
    {
        if (canJump)
        {
            hasJumped = true;
            VSpeed = JumpSpeed;
        }
    }

    public void Die()
    {
        print("ded");
        GameManager.Instance.ShowEndGameScreen();
    }
}
