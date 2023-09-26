using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerthingmovement : MonoBehaviour
{
    public float MovementSpeedPerSecond = 10.0f;
    // Update is called once per frame
    void Update()

    {
        //Up
        if (Input.Getkey(KeyCode.W))
´   {
            Vector3 characterposition = transform.position;
            characterposition.y = MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterposition;

        }

        //Down
        if (Input.Getkey(KeyCode.S))
        {

        }
        //Left 

        //Right 
    }
}
