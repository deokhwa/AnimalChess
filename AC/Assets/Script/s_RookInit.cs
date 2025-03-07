using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class s_RookInit : MonoBehaviour
{
    GameObject Piece;

    public int health;
    public int attack;
    int pos_x;
    int pos_z;
    public s_BoardInfo BoardInfo;

    public GameObject AbleToMove;

    // Start is called before the first frame update
    void Start()
    {
        health = UnityEngine.Random.Range(1, 5);
        attack = UnityEngine.Random.Range(1, 5);
        Piece = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        pos_x = (int)transform.position.x;
        pos_z = (int)transform.position.z;
        if (BoardInfo.IsGameStart) { RookMove(); }
    }
    public void MoveCondition() {
        if (0 <= pos_x && pos_x <= 7 && 0 <= pos_z && pos_z <= 7)
        {
            for (int i = pos_x + 1; i <= 7; i++)
            {
                if (BoardInfo.Board[i, pos_z] == null)
                {
                    Instantiate(AbleToMove, new Vector3(i, 0.1f, pos_z), Quaternion.identity);
                }
                else { break; }
            }
            for (int i = pos_x - 1; i >= 0; i--)
            {
                if (BoardInfo.Board[i, pos_z] == null)
                {
                    Instantiate(AbleToMove, new Vector3(i, 0.1f, pos_z), Quaternion.identity);
                }
                else { break; }
            }
            for (int i = pos_z + 1; i <= 7; i++)
            {
                if (BoardInfo.Board[pos_x, i] == null)
                {
                    Instantiate(AbleToMove, new Vector3(pos_x, 0.1f, i), Quaternion.identity);
                }
                else { break; }
            }
            for (int i = pos_z - 1; i >= 0; i--)
            {
                if (BoardInfo.Board[pos_x, i] == null)
                {
                    Instantiate(AbleToMove, new Vector3(pos_x, 0.1f, i), Quaternion.identity);
                }
                else { break; }
            }
        }

    }


    public void RookMove() {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Player_Rook" && Piece == null)
                {
                    Piece = hit.collider.gameObject;
                    MoveCondition();
                }
                else if (hit.collider.gameObject.tag == "MoveFlag" && Piece != null)
                {
                    BoardInfo.Board[(int)Piece.transform.position.x, (int)Piece.transform.position.z] = null;
                    BoardInfo.Board[(int)hit.collider.gameObject.transform.position.x, (int)hit.collider.gameObject.transform.position.z] = hit.collider.gameObject;
                    Piece.transform.position = hit.collider.gameObject.transform.position;
                    Piece = null;
                }
                else {
                    Piece = null;
                }
            }
            if (Piece == null)
            {
                GameObject[] objects = GameObject.FindGameObjectsWithTag("MoveFlag");
                foreach (GameObject obj in objects)
                {
                    Destroy(obj);
                }
            }

        }
        
    }
        /*
    public void MoveCondition() {

        //Collider[] hitColliders = Physics.OverlapSphere(new Vector3(pos_x, 0, pos_z), 0.4f);
        //foreach (var collider in hitColliders)
        //{
        //    Debug.Log("°ãÄ¡´Â ¹°Ã¼: " + collider.gameObject.name);
        //}

        for (int i = pos_x; i <= 7; i++) {
            Collider[] hitColliders = Physics.OverlapSphere(new Vector3(i,0,pos_z), 0.4f);
            foreach (var collider in hitColliders)
            {
                Debug.Log("i:" + i + "pos_z: "+ pos_z + "°ãÄ¡´Â ¹°Ã¼: " + collider.gameObject.name);
            }
        }
        for (int i = pos_x; i >= 0; i--)
        {
            Collider[] hitColliders = Physics.OverlapSphere(new Vector3(i, 0, pos_z), 0.4f);
            foreach (var collider in hitColliders)
            {
                Debug.Log("i:" + i + "pos_z: " + pos_z + "°ãÄ¡´Â ¹°Ã¼: " + collider.gameObject.name);
            }
        }
        for (int i = pos_z; i <= 7; i++)
        {
            Collider[] hitColliders = Physics.OverlapSphere(new Vector3(pos_x, 0, i), 0.4f);
            foreach (var collider in hitColliders)
            {
                Debug.Log("pos_x:" + pos_x + "i: " + i + "°ãÄ¡´Â ¹°Ã¼: " + collider.gameObject.name);
            }
        }
        for (int i = pos_z; i >= 0; i--)
        {
            Collider[] hitColliders = Physics.OverlapSphere(new Vector3(pos_x, 0, i), 0.4f);
            foreach (var collider in hitColliders)
            {
                Debug.Log("pos_x:" + pos_x + "i: " + i + "°ãÄ¡´Â ¹°Ã¼: " + collider.gameObject.name);
            }
        }


    }
    */
}
