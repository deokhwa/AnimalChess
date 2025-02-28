using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class s_Promotion : MonoBehaviour
{
    // Start is called before the first frame update

    KeyCode Promotion;
    public GameObject Promotion_Pawn;
    public GameObject Destroy_object;

    void Start()
    {
        Promotion = KeyCode.P;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Promotion))
        {
            Instantiate(Promotion_Pawn, new Vector3(3.5f, 0.5f, 3.5f), Quaternion.Euler(-90, 0, 0));
            Destroy(Destroy_object);
        }
    }


}

