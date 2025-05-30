using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playercontrolller : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    private Vector3 direksi;
    public float speed;
    public float speed1;


    private int desiredlane = 1;
   
    public float lanedistance = 4;

    public float lerpspeed = 80f;
    public float jumpforce = 10f;
    public float gravitasi = -10f;
    public string namatag = "obstacle";
    public float currentXdong = 0f;
    public Animator animatorplayer;

    
    public float slideDuration = 1.5f;




    void Start()
    {
        controller = GetComponent<CharacterController>();
        speed1 = speed;

    }

    // Update is called once per frame
    void Update()
    {
       
        
        direksi.z = speed;




        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || SwipeManager.swipeUp)
            {
                jump();


            }

            if (SwipeManager.swipeDown || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Slide();
            }
            
            
            if ( Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = 15f;
            }
            else
            {
                speed = speed1;
            }

      

        }
        else
        {
            direksi.y += gravitasi * Time.deltaTime;
            
        }
       

        if (Input.GetKeyDown(KeyCode.RightArrow) || SwipeManager.swipeRight)
        {
            desiredlane++;
            if (desiredlane == 3)
            {
                desiredlane = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || SwipeManager.swipeLeft)
        {
            desiredlane--;
            if (desiredlane == -1)
            {
                desiredlane = 0;
            }
        }
        float currentX = 0f;

        
        
        if (desiredlane == 0)
        {
            currentX = -lanedistance + 1f;
        }
        else if (desiredlane == 1)
        {
            currentX = currentXdong;
        }
        else if (desiredlane == 2)
        {
            currentX = lanedistance;
        }
        //Vector3 targetposisi = transform.position.z * transform.forward + transform.position.y * transform.up;
        Vector3 targetposisi = transform.position.z * transform.forward +
                               transform.position.y * transform.up +
                               Vector3.right * currentX;

        //if (desiredlane == 0)
        //{
        //    targetposisi += Vector3.left * lanedistance;
        //}
        //else if (desiredlane == 2)
        //{
        //    targetposisi += Vector3.right * lanedistance;
        //}

        //transform.position = Vector3.Lerp(transform.position, targetposisi, lerpspeed * Time.fixedDeltaTime);



        if (transform.position == targetposisi)
            return;
        Vector3 diff = targetposisi - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            controller.Move(moveDir);
        }
        else
        {
            controller.Move(diff);
        }




    }

    private void FixedUpdate()
    {
        if (!player_manager.Started)
            return;
        controller.Move(direksi * Time.deltaTime);
        Vector3 target1= transform.position.z * transform.forward + transform.position.y * transform.up;
    }


    private void jump()
    {
        direksi.y = jumpforce;
        animatorplayer.SetBool("jump", true);
        animatorplayer.SetBool("run", false);
        StartCoroutine(CallCodeA());
    }
    private void Slide()
    {
        
        animatorplayer.SetBool("slide", true);
        animatorplayer.SetBool("run", false);
        controller.center = new Vector3(0, 0, 0);
        controller.height = 0.001f;
        StartCoroutine(CallCodeB());
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == namatag)
        {
            player_manager.GameOver = true;
            
        }
    }
  
    void CodeA()
    {
        animatorplayer.SetBool("run", true);
        animatorplayer.SetBool("jump", false);


   

    }void CodeB()
    {
        

        animatorplayer.SetBool("slide", false);
        animatorplayer.SetBool("run",  true);
        controller.center = new Vector3(0, 0.02f, 0);
        controller.height = 0.04f;

    }


    IEnumerator CallCodeA()
    {
       
        yield return new WaitForSeconds(0.5f); // Menunggu 2 detik

        CodeA(); // Memanggil method CodeA
    }
    private IEnumerator CallCodeB()
    {


        yield return new WaitForSeconds(1f);
        CodeB();
        
    }
}
