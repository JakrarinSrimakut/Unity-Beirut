using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongScript : MonoBehaviour
{
    private Touch touch;
    private Vector2 startPos, direction;
    private float touchTImeStart, timeInterval; //calculate swipe time to control throw force in z direction
    private Vector3 ballStartPos;

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
                    Invoke("ResetBall", 3f);
                    break;
            }
        }
    }
    void ResetBall()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);
        GetComponent<Transform>().rotation = Quaternion.Euler(0f,0f,0f);
        GetComponent<Transform>().position = ballStartPos;
        GetComponent<Rigidbody>().useGravity = false;
    }
}
