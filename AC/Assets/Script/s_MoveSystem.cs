using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class s_MoveSystem : MonoBehaviour
{
    public s_BoardInfo BoardInfo;


    private string[] PieceTypes;
    private string PieceType;

    private GameObject CurrentPiece;
    private bool PlayerPieceCheck;
    private int idx;

    public List<GameObject> CanAttack;
    // Start is called before the first frame update
    void Start()
    {
        PieceTypes = new string[7];
        PieceTypes[0] = "Player_King";
        PieceTypes[1] = "Player_Queen";
        PieceTypes[2] = "Player_Rook";
        PieceTypes[3] = "Player_Knight";
        PieceTypes[4] = "Player_Bishop";
        PieceTypes[5] = "Player_Pawn";
        PieceTypes[6] = "Player_Promation_Pawn";

    }

    // Update is called once per frame
    void Update()
    {
        if (BoardInfo.IsGameStart) { Move(); }
    }

    public void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                PlayerPieceCheck = false;
                for (idx = 0; idx < 7; idx++) {
                    if (hit.collider.gameObject.name == PieceTypes[idx]) {
                        PieceType = PieceTypes[idx];
                        CurrentPiece = hit.collider.gameObject;
                        PlayerPieceCheck = true;
                        break;
                    }
                }
                if (PlayerPieceCheck && BoardInfo.SelectiedPiece == null)
                {
                    BoardInfo.SelectiedPiece = hit.collider.gameObject;
                    if (idx == 0) { CurrentPiece.GetComponent<s_KingInit>().MoveCondition(); CanAttack = CurrentPiece.GetComponent<s_KingInit>().CanAttack; }
                    else if (idx == 1) { CurrentPiece.GetComponent<s_QueenInit>().MoveCondition(); CanAttack = CurrentPiece.GetComponent<s_QueenInit>().CanAttack; }
                    else if (idx == 2) { CurrentPiece.GetComponent<s_RookInit>().MoveCondition(); CanAttack = CurrentPiece.GetComponent<s_RookInit>().CanAttack; }
                    else if (idx == 3) { CurrentPiece.GetComponent<s_KnightInit>().MoveCondition(); CanAttack = CurrentPiece.GetComponent<s_KnightInit>().CanAttack; }
                    else if (idx == 4) { CurrentPiece.GetComponent<s_BishopInit>().MoveCondition(); CanAttack = CurrentPiece.GetComponent<s_BishopInit>().CanAttack; }
                    else if (idx == 5) { CurrentPiece.GetComponent<s_PawnInit>().MoveCondition(); CanAttack = CurrentPiece.GetComponent<s_PawnInit>().CanAttack; }
                    else if (idx == 6) { CurrentPiece.GetComponent<s_BishopInit>().MoveCondition(); CanAttack = CurrentPiece.GetComponent<s_BishopInit>().CanAttack; }
                }
                else if (hit.collider.gameObject.tag == "MoveFlag" && BoardInfo.SelectiedPiece != null)
                {
                    //Move
                    BoardInfo.Board[(int)hit.collider.gameObject.transform.position.x, (int)hit.collider.gameObject.transform.position.z] = BoardInfo.SelectiedPiece;
                    BoardInfo.Board[(int)BoardInfo.SelectiedPiece.transform.position.x, (int)BoardInfo.SelectiedPiece.transform.position.z] = null;                    
                    BoardInfo.SelectiedPiece.transform.position = hit.collider.gameObject.transform.position;
                    BoardInfo.SelectiedPiece = null;
                    CanAttack.Clear();
                }
                else if (CanAttack.Contains(hit.collider.gameObject))
                {
                    //NormalAttack
                    BoardInfo.Board[(int)BoardInfo.SelectiedPiece.transform.position.x, (int)BoardInfo.SelectiedPiece.transform.position.z] = null;
                    BoardInfo.Board[(int)hit.collider.gameObject.transform.position.x, (int)hit.collider.gameObject.transform.position.z] = hit.collider.gameObject;
                    BoardInfo.SelectiedPiece.transform.position = hit.collider.gameObject.transform.position;
                    Destroy(hit.collider.gameObject);
                    BoardInfo.SelectiedPiece = null;
                    CanAttack.Clear();
                }
                else
                {
                    //MissClick
                    BoardInfo.SelectiedPiece = null;
                    CanAttack.Clear();
                }
            }
            if (BoardInfo.SelectiedPiece == null)
            {
                GameObject[] objects = GameObject.FindGameObjectsWithTag("MoveFlag");
                foreach (GameObject obj in objects)
                {
                    Destroy(obj);
                }
            }
        }

    }


}
