using UnityEngine;
using System.Collections;

public class PlayerPointHolder : MonoBehaviour {

    public GameObject player;


    void LateUpdate()
    {
        Vector3 t = player.transform.position;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, t.z);
    }
}
