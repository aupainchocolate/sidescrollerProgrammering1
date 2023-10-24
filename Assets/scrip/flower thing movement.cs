using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public enum CharacterState
{
 Grounded = 0,
 Airborne = 1,
 Jumping = 2,

 Total 
}   

public class flowerthingmovement : MonoBehaviour
{
    public CharacterState JumpingState = CharacterState.Airborne;

    //gravity
    public float GroundLevel = 0.0f;
    public float GravitySpeed = 10.0f;

    //Jump
    public float JumpSpeedFactor = 2.0f;
    public float JumpMaxHeight = 4.0f;
    private float JumpHeightDelta = 0.0f;

    //MOvement
    public float MovementSpeed = 10.0f; 


    void Update()
    {
       if(transform.position.y <= GroundLevel)
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y = GroundLevel;
            transform.position = characterPosition;
            JumpingState = CharacterState.Grounded;
        } 
    
        //Up
        if (Input.GetKey(KeyCode.W) && JumpingState == CharacterState.Grounded) 
        {
            JumpingState = CharacterState.Jumping;
            JumpHeightDelta = 0.0f;
        }
        if(JumpingState == CharacterState.Jumping)
        {
            Vector3 characterposition = transform.position;
            float totalJumpMovementThisFrame = MovementSpeed* JumpSpeedFactor* Time.deltaTime;
            characterposition.y += totalJumpMovementThisFrame;
            transform.position = characterposition;
            JumpHeightDelta += totalJumpMovementThisFrame;

            if(JumpHeightDelta >= JumpMaxHeight )
            {
                JumpingState = CharacterState.Airborne;
                JumpHeightDelta = 0.0f;
            }
            
        }

        //Down
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 characterposition = transform.position;
            characterposition.y -= MovementSpeed * Time.deltaTime;
            transform.position = characterposition;
        }
        //Left 

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 characterposition = transform.position;
            characterposition.x -= MovementSpeed* Time.deltaTime;
            transform.position = characterposition;
        }
        //Right 
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 characterposition = transform.position;
            characterposition.x += MovementSpeed * Time.deltaTime;
            transform.position = characterposition;
        }
        if (JumpingState == CharacterState.Airborne)
        {
            Vector3 gravityPosition = transform.position;
            gravityPosition.y -= GravitySpeed * Time.deltaTime;
            if (gravityPosition.y < GroundLevel) { gravityPosition.y = GroundLevel; }
            transform.position = gravityPosition;
        }

    }






}
