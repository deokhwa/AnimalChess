using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_PawnInit : MonoBehaviour
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCondition()
    {
        pos_x = (int)transform.position.x;
        pos_z = (int)transform.position.z;
        CanAttack.Clear();

        NewPos_x = pos_x;
        NewPos_z = pos_z - 1;
        if (0 <= NewPos_x && NewPos_x <= 7 && 0 <= NewPos_z && NewPos_z <= 7)
        {
            if (BoardInfo.Board[NewPos_x, NewPos_z] == null)
            {
                Instantiate(AbleToMove, new Vector3(NewPos_x, 0.1f, NewPos_z), Quaternion.identity);
            }
        }
        NewPos_x = pos_x - 1;
        NewPos_z = pos_z - 1;
        if (0 <= NewPos_x && NewPos_x <= 7 && 0 <= NewPos_z && NewPos_z <= 7)
        {
            if (BoardInfo.Board[NewPos_x, NewPos_z] != null && BoardInfo.Board[NewPos_x, NewPos_z].tag == "E_Piece")
            {
                CanAttack.Add(BoardInfo.Board[NewPos_x, NewPos_z]);
            }
        }
        NewPos_x = pos_x + 1;
        NewPos_z = pos_z - 1;
        if (0 <= NewPos_x && NewPos_x <= 7 && 0 <= NewPos_z && NewPos_z <= 7)
        {
            if (BoardInfo.Board[NewPos_x, NewPos_z] != null && BoardInfo.Board[NewPos_x, NewPos_z].tag == "E_Piece")
            {
                CanAttack.Add(BoardInfo.Board[NewPos_x, NewPos_z]);
            }
        }
    }


}
