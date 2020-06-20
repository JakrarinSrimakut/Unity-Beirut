using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongScript : MonoBehaviour
{
    public int waitTime = 4;

    private Touch touch;
    private Vector2 startPos, direction;
    private float touchTImeStart, timeInterval; //calculate swipe time to control throw force in z direction
    private Vector3 ballStartPos;
    private bool ballInCup = false;
    

    [SerializeField]
    float throwForceInXandY = 1f; //control throw force of x and y direction

    [SerializeField]
    float throwForceInZ = 1f; //control throw force of z direction

    void Start()
    {
        //Keep ball floating until player can interact with it
        GetComponent<Rigidbody>().useGravity = false;
        ballStartPos = GetComponent<Transform>().position;
    }
    // Update is called once per frame
    void Update()
    {
        //Check if player touching screen
        if(Input.touchCount > 0)
        {
            //Get touch position
            touch = Input.GetTouch(0);

            //Check swipe
            switch (touch.phase)
            {
                //Screen touch
                case TouchPhase.Began:
                    touchTImeStart = Time.time;
                    startPos = touch.position;
                    break;
                // Release your finger
                case TouchPhase.Ended:
                    timeInterval = Time.time - touchTImeStart;
                    direction = touch.position - startPos;
                    //Add force to ball depending on direction, swipe time and throw force
                    GetComponent<Rigidbody>().AddForce(direction.x * throwForceInXandY,direction.y * throwForceInXandY, throwForceInZ/timeInterval);
                    GetComponent<Rigidbody>().useGravity = true;
                    //TODO: Test when ball goes in cup that the reset ball from trigger will cause problem with the one below .If so set a boolean 
                    //check for ballEnterCup to not trigger Reset ball below
                    
                    Invoke("ResetBallWhenMissed", waitTime);//wait to allow ball enough time to enter cup before checking if missed
                    break;
            }
        }
    }
    //check if ball is in cup if so dont run ResetBall() because that will be done from PlasticCupScript to be done at the same time with removeCup()
    public void ResetBallWhenMissed()
    {
        if (!ballInCup)//ball missed reset ball
        {
            Debug.Log("Ball not in cup");
            ResetBall();
        }
        else//ball in cup reset ballInCup to false for next throw
        {
            ballInCup = false;
        }
    }

    public void setBallInCupTrue()
    {
        ballInCup = true;
    }

    public void ResetBall()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);
        GetComponent<Transform>().rotation = Quaternion.Euler(0f,0f,0f);
        GetComponent<Transform>().position = ballStartPos;
        GetComponent<Rigidbody>().useGravity = false;
    }
}
