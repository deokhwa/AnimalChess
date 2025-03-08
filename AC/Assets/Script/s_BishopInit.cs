using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_BishopInit : MonoBehaviour
{
    public int health;
    public int attack;
    int pos_x;
    int pos_z;
    int NewPos_x;
    int NewPos_z;
    public s_BoardInfo BoardInfo;

    public GameObject AbleToMove;

    public List<GameObject> CanAttack;

    private (int, int)[] MoveDirection;
    // Start is called before the first frame update
    void Start()
    {
        health = UnityEngine.Random.Range(1, 5);
        attack = UnityEngine.Random.Range(1, 5);
        CanAttack = new List<GameObject>();

        MoveDirection = new (int, int)[4];
        MoveDirection[0] = (1, 1);
        MoveDirection[1] = (-1, 1);
        MoveDirection[2] = (1, -1);
        MoveDirection[3] = (-1, -1);
        
    }

    // Update is called once per frame
    void Update()
    {
        pos_x = (int)transform.position.x;
        pos_z = (int)transform.position.z;
        //if (BoardInfo.IsGameStart) { BishopMove(); }
    }
    public void MoveCondition()
    {
        foreach ((int, int) dir in MoveDirection) 
        {
           
            for (int i = 1; i <= 7; i++)
            {                
                NewPos_x = pos_x + (i * dir.Item1);
                NewPos_z = pos_z + (i * dir.Item2);
                if (0 <= NewPos_x && NewPos_x <= 7 && 0 <= NewPos_z && NewPos_z <= 7)
                {
                    if (BoardInfo.Board[NewPos_x,NewPos_z] == null)
                    {
                        Instantiate(AbleToMove, new Vector3(NewPos_x, 0.1f, NewPos_z), Quaternion.identity);   
                    }
                    else
                    {
                        if (BoardInfo.Board[NewPos_x, NewPos_z].tag == "E_Piece")
                        {
                            CanAttack.Add(BoardInfo.Board[NewPos_x,NewPos_z]);
                        }
                        break;
                    }
                }
                else { break; }
            }
        }
        if (CanAttack != null)
        {
            foreach (GameObject obj in CanAttack)
            {
                Debug.Log(obj.name);
            }
        }
    }

    /*
    public void BishopMove()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Player_Bishop" && BoardInfo.SelectiedPiece == null)
                {
                    BoardInfo.SelectiedPiece = hit.collider.gameObject;
                    MoveCondition();
                }
                else if (hit.collider.gameObject.tag == "MoveFlag" && BoardInfo.SelectiedPiece != null)
                {
                    BoardInfo.Board[(int)BoardInfo.SelectiedPiece.transform.position.x, (int)BoardInfo.SelectiedPiece.transform.position.z] = null;
                    BoardInfo.Board[(int)hit.collider.gameObject.transform.position.x, (int)hit.collider.gameObject.transform.position.z] = hit.collider.gameObject;
                    BoardInfo.SelectiedPiece.transform.position = hit.collider.gameObject.transform.position;
                    BoardInfo.SelectiedPiece = null;
                }
                else if (CanAttack.Contains(hit.collider.gameObject))
                {
                    //NormalAttack
                    BoardInfo.Board[(int)BoardInfo.SelectiedPiece.transform.position.x, (int)BoardInfo.SelectiedPiece.transform.position.z] = null;
                    BoardInfo.Board[(int)hit.collider.gameObject.transform.position.x, (int)hit.collider.gameObject.transform.position.z] = hit.collider.gameObject;
                    BoardInfo.SelectiedPiece.transform.position = hit.collider.gameObject.transform.position;
                    Destroy(hit.collider.gameObject);
                    BoardInfo.SelectiedPiece = null;
                }
                else
                {
                    BoardInfo.SelectiedPiece = null;
                }
            }
            if (BoardInfo.SelectiedPiece == null)
            {
                Debug.Log("DestroyByBishop");
                GameObject[] objects = GameObject.FindGameObjectsWithTag("MoveFlag");
                foreach (GameObject obj in objects)
                {
                    Destroy(obj);
                }
                CanAttack.Clear(); 
            }


        }

    }
    */
}
