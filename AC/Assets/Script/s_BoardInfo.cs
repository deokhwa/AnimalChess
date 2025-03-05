using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_BoardInfo : MonoBehaviour
{
    public GameObject[,] Board;
    int pos_x;
    int pos_z;
    public bool IsGameStart;
    // Start is called before the first frame update
    void Start()
    {
        IsGameStart = false;
        Board = new GameObject[8,8];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Board[i, j] = null;

            }
        }

    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BoardInitialize() {
        
        GameObject[] objects1 = GameObject.FindGameObjectsWithTag("P_Piece");
        foreach (GameObject obj in objects1)
        {
            pos_x = (int)obj.transform.position.x;
            pos_z = (int)obj.transform.position.z;
            if (0 <= pos_x && pos_x <= 7) {
                if (0 <= pos_z && pos_z <= 7) {
                    Board[pos_x, pos_z] = obj;
                }
            }
        }
        GameObject[] objects2 = GameObject.FindGameObjectsWithTag("E_Piece");
        foreach (GameObject obj in objects2)
        {
            pos_x = (int)obj.transform.position.x;
            pos_z = (int)obj.transform.position.z;
            if (0 <= pos_x && pos_x <= 7)
            {
                if (0 <= pos_z && pos_z <= 7)
                {
                    Board[pos_x, pos_z] = obj;
                }
            }
        }

        /*
        for (int k = 0; k < 8; k++)
        {
            for (int l = 0; l < 8; l++)
            {
                Debug.Log(k + " " + l + " " + Board[k, l]);
                if (Board[k, l] != null)
                { Debug.Log(k + " " + l + " " + "check"); }
            }
        }
        */
    }


}
