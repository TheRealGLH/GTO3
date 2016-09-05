using UnityEngine;
using System.Collections.Generic;

public class levelGenerator : MonoBehaviour {


    [Header("Level pieces")]
    public GameObject emptyPiece;
    public List<GameObject> easyPieces;
    [Header("Settings")]
    public int timeUntilMedium;
    public int timeUntilHard;
    private int currTime;


}
