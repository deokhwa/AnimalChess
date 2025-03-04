using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_RookInit : MonoBehaviour
{

    int health;
    int attack;
    int pos_x;
    int pos_z;
    

    // Start is called before the first frame update
    void Start()
    {
        health = UnityEngine.Random.Range(1, 5);
        attack = UnityEngine.Random.Range(1, 5);
        

    }

    // Update is called once per frame
    void Update()
    {
        pos_x = (int)transform.position.x;
        pos_z = (int)transform.position.z;
    }

    public void MoveCondition() {
        Debug.Log("123");
        Debug.Log(pos_x);
        Debug.Log(pos_z);
        for (int i = pos_x; i < 8; i++) {
            Collider[] hitColliders = Physics.OverlapSphere(new Vector3(i,0,pos_z), 1f);
            foreach (var collider in hitColliders)
            {
                Debug.Log("°ãÄ¡´Â ¹°Ã¼: " + collider.gameObject.name);
            }
        }
        for (int i = pos_x; i > 0; i--)
        {
            Collider[] hitColliders = Physics.OverlapSphere(new Vector3(i, 0, pos_z), 0.5f);
            foreach (var collider in hitColliders)
            {
                Debug.Log("°ãÄ¡´Â ¹°Ã¼: " + collider.gameObject.name);
            }
        }
        for (int i = pos_z; i < 8; i++)
        {
            Collider[] hitColliders = Physics.OverlapSphere(new Vector3(pos_x, 0, i), 0.5f);
            foreach (var collider in hitColliders)
            {
                Debug.Log("°ãÄ¡´Â ¹°Ã¼: " + collider.gameObject.name);
            }
        }
        for (int i = pos_z; i > 0; i--)
        {
            Collider[] hitColliders = Physics.OverlapSphere(new Vector3(pos_x, 0, i), 0.5f);
            foreach (var collider in hitColliders)
            {
                Debug.Log("°ãÄ¡´Â ¹°Ã¼: " + collider.gameObject.name);
            }
        }
    }



}
