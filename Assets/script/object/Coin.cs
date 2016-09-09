using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    public GameObject coinModel;
    public float rotateSpeed;//100% rotatey!
    private Transform c;

    void Start()
    {
        c = coinModel.transform;
    }

    void Update()
    {
        c.Rotate(Vector3.back, rotateSpeed);
    }

}
