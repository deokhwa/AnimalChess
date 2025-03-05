using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_GameStart : MonoBehaviour
{
    public GameObject[] canvases;
    public s_BoardInfo BoardInfo;

    
    // Start is called before the first frame update
    void Start()
    {
        canvases[0].SetActive(true);
        canvases[1].SetActive(false);
        BoardInfo = FindObjectOfType<s_BoardInfo>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Piece_State");
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
        canvases[0].SetActive(false);
        canvases[1].SetActive(true);

        BoardInfo.IsGameStart = true;

        BoardInfo.BoardInitialize();
    }


}
