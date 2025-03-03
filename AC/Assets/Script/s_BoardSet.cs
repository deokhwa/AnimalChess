using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_BoardSet : MonoBehaviour
{

    GameObject Piece;

    // Start is called before the first frame update
    void Start()
    {
        Piece = null;
    }

    // Update is called once per frame
    void Update()
    {
        PointAndClick();
    }

    void PointAndClick() {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "P_Piece") {
                    Piece = hit.collider.gameObject;
                }
                else if (hit.collider.gameObject.tag == "Piece_State" && Piece != null){
                    Piece.transform.position = hit.collider.gameObject.transform.position;
                    Piece = null;
                }
                
            }

        }
    }
}
