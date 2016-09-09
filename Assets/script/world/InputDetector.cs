using UnityEngine;
using System.Collections;

public class InputDetector : MonoBehaviour {

    public GameObject Player;
    private Player player;

     private float fingerStartTime  = 0.0f;
  private Vector2 fingerStartPos = Vector2.zero;
  
  private bool isSwipe = false;
  private float minSwipeDist  = 50.0f;
  private float maxSwipeTime = 0.5f;

  
  // Update is called once per frame
  void Update()
  {

      if (Input.touchCount > 0)
      {

          foreach (Touch touch in Input.touches)
          {
              switch (touch.phase)
              {
                  case TouchPhase.Began:
                      /* this is a new touch */
                      isSwipe = true;
                      fingerStartTime = Time.time;
                      fingerStartPos = touch.position;
                      break;

                  case TouchPhase.Canceled:
                      /* The touch is being canceled */
                      isSwipe = false;
                      break;

                  case TouchPhase.Ended:

                      float gestureTime = Time.time - fingerStartTime;
                      float gestureDist = (touch.position - fingerStartPos).magnitude;

                      if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
                      {
                          Vector2 direction = touch.position - fingerStartPos;
                          Vector2 swipeType = Vector2.zero;

                          if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                          {
                              // the swipe is horizontal:
                              swipeType = Vector2.right * Mathf.Sign(direction.x);
                          }
                          else
                          {
                              // the swipe is vertical:
                              swipeType = Vector2.up * Mathf.Sign(direction.y);
                          }

                          if (swipeType.x != 0.0f)
                          {
                              if (swipeType.x > 0.0f)
                              {
                                  player.MoveLeft();
                              }
                              else
                              {
                                  player.MoveRight();
                              }
                          }

                          if (swipeType.y != 0.0f)
                          {
                              if (swipeType.y > 0.0f)
                              {
                                  player.Jump();
                              }
                              else
                              {
                                  // MOVE DOWN
                              }
                          }
                      }
                      break;
              }
          }
      }

      if (Input.GetKeyDown(KeyCode.A))
      {
          player.MoveLeft();
      }
      else if (Input.GetKeyDown(KeyCode.D))
      {
          player.MoveRight();
      }
      if (Input.GetKeyDown(KeyCode.Space))
      {
          player.Jump();
      }
  }
    
    void Start()
    {
        player = Player.GetComponent<Player>();
    }


    void FixedUpdate()
    {
        
    }
}
