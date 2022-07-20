using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform myTransform;
    [SerializeField] float moveVel = 1;
    
    
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            myTransform.position += Vector3.right * moveVel * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * -moveVel * Time.deltaTime;
        }
    }
 
}
