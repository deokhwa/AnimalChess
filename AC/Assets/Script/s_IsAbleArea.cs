using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_IsAbleArea : MonoBehaviour
{
    public GameObject able;
    public GameObject disable;
    public GameObject checker;
    Vector3 Position;
    bool state_able;
    int axis_x;
    int axis_z;
    Collider otherCollider;

    // Start is called before the first frame update
    void Start(){
        state_able = true;

        otherCollider = otherObject.GetComponent<Collider>();

        for (int axis_x = 0; axis_x < 8; axis_x++){
            for (int axis_z = 0; axis_z < 8; axis_z++){
                Position = new Vector3(axis_x, 0.6f, axis_z);
                checker.transform.position = Position;
                //Debug.Log(Position);
                if (Physics.CheckBox(transform.position, new Vector3(1/2, 1/2, 1/2), Quaternion.identity)){
                    Debug.Log("123123");
                }
                
            }
        }
    }

    // Update is called once per frame
    void Update(){

    }



    void OnTriggerEnter(Collider other)
    {
        // 다른 물체가 트리거 영역에 들어왔을 때
        Debug.Log("asdasd");
        Instantiate(able, checker.transform.position, Quaternion.identity);

    }




}
