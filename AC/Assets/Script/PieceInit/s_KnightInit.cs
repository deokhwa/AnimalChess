using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_KnightInit : MonoBehaviour
{
    public int health;
    public int attack;
    int pos_x;
    int pos_z;
    public s_BoardInfo BoardInfo;

    public GameObject AbleToMove;

    public List<GameObject> CanAttack;

    private (int, int)[] MoveDirection;
    int NewPos_x;
    int NewPos_z;

    // Start is called before the first frame update
    void Start()
    {
        health = UnityEngine.Random.Range(1, 5);
        attack = UnityEngine.Random.Range(1, 5);
        CanAttack = new List<GameObject>();

        MoveDirection = new (int, int)[8];
        MoveDirection[0] = (1, 2);
        MoveDirection[1] = (1, -2);
        MoveDirection[2] = (-1, 2);
        MoveDirection[3] = (-1, -2);
        MoveDirection[4] = (2, 1);
        MoveDirection[5] = (2, -1);
        MoveDirection[6] = (-2, 1);
        MoveDirection[7] = (-2, -1);
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
        for (int i = 0; i < 8; i++)
        {
            NewPos_x = pos_x + MoveDirection[i].Item1;
            NewPos_z = pos_z + MoveDirection[i].Item2;
            if (0 <= NewPos_x && NewPos_x <= 7 && 0 <= NewPos_z && NewPos_z <= 7)
            {
                if (BoardInfo.Board[NewPos_x, NewPos_z] == null)
                {
                    Instantiate(AbleToMove, new Vector3(NewPos_x, 0.1f, NewPos_z), Quaternion.identity);
                }
                else
                {
                    if (BoardInfo.Board[NewPos_x, NewPos_z].tag == "E_Piece")
                    {
                        CanAttack.Add(BoardInfo.Board[NewPos_x, NewPos_z]);
                    }
                }
            }
        }
        
        /*
        if (CanAttack != null)
        {
            foreach (GameObject obj in CanAttack)
            {
                Debug.Log(obj.name);
            }
        }
        */
        
    }




}
