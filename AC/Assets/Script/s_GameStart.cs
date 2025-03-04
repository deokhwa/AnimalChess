using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_GameStart : MonoBehaviour
{
    public GameObject[] canvases;
    // Start is called before the first frame update
    void Start()
    {
        canvases[0].SetActive(true);
        canvases[1].SetActive(false);
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
    }


}
