using UnityEngine;
using System.Collections.Generic;

public enum GameDifficulty
{
    easy,
    medium,
    hard,
    EuropeanExtreme
}

public class levelGenerator : MonoBehaviour {


    [Header("Level pieces")]
    public GameObject levelHolder;
    public GameObject emptyPiece;
    public List<GameObject> easyPieces;
    public List<GameObject> mediumPieces;
    public List<GameObject> hardPieces;
    public List<GameObject> EuropeanEXTREMEPieces;
    public List<GameObject> emptyLanePieces;
    [Header("Other Objects")]
    [Header("Settings")]
    public int piecesBehindStart;
    public int timeUntilMedium;
    public int timeUntilHard;
    public int beginBreathingRoom;
    private int currBreathingRoom;
    public int PiecesUntilBeginToHard;
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
    private List<GameObject> piecesSet;
    private GameDifficulty currentDifficulty = GameDifficulty.easy;



    void FixedUpdate()
    {

    }

    void Start()
    {
        piecesSet = easyPieces;
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
        if (piecesCounter > timeUntilMedium&&currentDifficulty==GameDifficulty.easy) UpDifficulty(GameDifficulty.medium);
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
        if (beginHasPassed) GameManager.Instance.RaiseScore(GameManager.Instance.scoreRaiseAmount);
        latestPiece = currpiece;
        piecesCounter++;
    }

    GameObject getPiece()
    {
        if(breathingRoomCounter == breathingRoom)
        {
            breathingRoomCounter = 0;
            return GameObject.Instantiate(piecesSet[Random.Range(0, piecesSet.Count)]);           
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


    void UpDifficulty(GameDifficulty diff)
    {
        switch (diff)
        {
            case GameDifficulty.easy:
                Debug.LogError("INVALID DIFFICULTY!!");
                //This is never supposed to happen, is it?
                break;
            case GameDifficulty.medium:
                breathingRoom -= 3;
                piecesSet = mediumPieces;
                break;
            case GameDifficulty.hard:
                Debug.LogError("INVALID DIFFICULTY!!");
                break;
            case GameDifficulty.EuropeanExtreme:
                Debug.LogError("INVALID DIFFICULTY!!");

                break;
            default:
                Debug.LogError("INVALID DIFFICULTY!!");
                break;
        }
        GameManager.Instance.RaiseDifficulty(diff);
        currentDifficulty = diff;
    }



}
