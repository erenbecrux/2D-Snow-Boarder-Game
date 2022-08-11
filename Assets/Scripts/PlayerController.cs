using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;


    [SerializeField] float torqueValue = 1f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    void PlayerRotation()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueValue);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueValue);
            
        }
    }

    void RespondToBoost()
    {

        
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;

        }
        else 
        {
            surfaceEffector2D.speed = baseSpeed;
        }

    }

    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove==true)
        {
            PlayerRotation();
            RespondToBoost();
        }
        
        


    }

    public void DisableControls()
    {
        canMove = false;
    }
    
}
