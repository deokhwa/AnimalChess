using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class s_GoToStage1 : MonoBehaviour
{
    KeyCode v_Start_Button;

    // Start is called before the first frame update
    void Start()
    {

        v_Start_Button = KeyCode.S;
        

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(v_Start_Button))
        {
            SceneManager.LoadScene("Stage1");
        }
    }
}