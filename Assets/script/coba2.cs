using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coba2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float movespeed = 5f;
    public float gravitasi = -9.81f;
    public CharacterController controller;
    private Vector3 velocity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizon = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movedireksi= transform.right*horizon + transform.forward*vertical;
        controller.Move(movedireksi * movespeed * Time.deltaTime);

        if (!controller.isGrounded)
        {
            velocity.y += gravitasi * Time.deltaTime;
        }
        else
        {
            velocity.y = -2f;
        }

        controller.Move(velocity * Time.deltaTime);

    }
   
}
