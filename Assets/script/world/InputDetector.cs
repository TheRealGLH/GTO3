using UnityEngine;
using System.Collections;

public class InputDetector : MonoBehaviour {

    public GameObject Player;
    private Player player;

    void Start()
    {
        player = Player.GetComponent<Player>();
    }


    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            player.MoveLeft();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            player.MoveRight();
        }
    }
}
