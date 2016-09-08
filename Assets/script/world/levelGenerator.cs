using UnityEngine;
using System.Collections.Generic;

public class levelGenerator : MonoBehaviour {


    [Header("Level pieces")]
    public GameObject levelHolder;
    public GameObject emptyPiece;
    public List<GameObject> easyPieces;
    [Header("Other Objects")]
    [Header("Settings")]
    public int piecesBehindStart;
    public int timeUntilMedium;
    public int timeUntilHard;
    public int beginBreathingRoom;
    private bool beginHasPassed = false;
    public int breathingRoom;
    private int breathingRoomCounter = 0;
    private int piecesCounter;
    private List<GameObject> levelPieces = new List<GameObject>();
    public int FieldOfView;
    public float nextSpawn;
    private float SpawnTimer;
    private bool isPaused;
    private GameObject latestPiece;



    void FixedUpdate()
    {

    }

    void Start()
    {
        piecesCounter = -piecesBehindStart;
        //the level you will see behind you
        for (int i = 0; i < piecesBehindStart; i++)
        {
            SpawnPiece(true);
        }

        //actual level
        for (int i = 0; i < FieldOfView; i++)
        {
            SpawnPiece();
        }
    }

    public void NextPiece()
    {
        SpawnPiece();
    }


    void SpawnPiece(bool forceEmpty = false)
    {
        if (piecesCounter > beginBreathingRoom) beginHasPassed = true;
        GameObject currpiece;
        if(!beginHasPassed||forceEmpty)
        {
             currpiece = GameObject.Instantiate(emptyPiece);
        }
        else
        {
            currpiece = getPiece();
        }
        Vector3 e = currpiece.transform.position;
        currpiece.transform.parent = levelHolder.transform;
        currpiece.transform.position = new Vector3(e.x, e.y, (float)piecesCounter);
        levelPieces.Add(currpiece);
        if(levelPieces.Count>FieldOfView)
        {
            GameObject piece = levelPieces[0];
            levelPieces.Remove(piece);
            GameObject.Destroy(piece);
        }
        latestPiece = currpiece;
        piecesCounter++;
    }

    GameObject getPiece()
    {
        if(breathingRoomCounter == breathingRoom)
        {
            breathingRoomCounter = 0;
            return GameObject.Instantiate(easyPieces[Random.Range(0, easyPieces.Count)]);           
        }
        else
        {
            breathingRoomCounter++;
            return GameObject.Instantiate(emptyPiece);
        }
    }

    public GameObject GetLatestPiece()
    {
        return latestPiece;
    }


}
