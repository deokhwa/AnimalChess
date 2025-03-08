using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class s_MoveSystem : MonoBehaviour
{
    public s_BoardInfo BoardInfo;
    public s_BishopInit Bishop;
    public s_RookInit Rook;
    

    // Start is called before the first frame update
    void Start()
    {
        
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
                if (hit.collider.gameObject.name == "Player_Bishop" && BoardInfo.SelectiedPiece == null)
                {
                    BoardInfo.SelectiedPiece = hit.collider.gameObject;
                    Bishop.MoveCondition();
                }
                else if (hit.collider.gameObject.tag == "MoveFlag" && BoardInfo.SelectiedPiece != null)
                {
                    BoardInfo.Board[(int)BoardInfo.SelectiedPiece.transform.position.x, (int)BoardInfo.SelectiedPiece.transform.position.z] = null;
                    BoardInfo.Board[(int)hit.collider.gameObject.transform.position.x, (int)hit.collider.gameObject.transform.position.z] = hit.collider.gameObject;
                    BoardInfo.SelectiedPiece.transform.position = hit.collider.gameObject.transform.position;
                    BoardInfo.SelectiedPiece = null;
                }
                else if (Bishop.CanAttack.Contains(hit.collider.gameObject))
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
                GameObject[] objects = GameObject.FindGameObjectsWithTag("MoveFlag");
                foreach (GameObject obj in objects)
                {
                    Destroy(obj);
                }
                Bishop.CanAttack.Clear();
            }
        }

    }


}
