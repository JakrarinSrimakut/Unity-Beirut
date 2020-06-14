using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongScript : MonoBehaviour
{

    private Touch touch;
    private Vector2 startPos, direction;
    float touchTImeStart, timeInterval; //calculate swipe time to control throw force in z direction

    [SerializeField]
    float throwForceInXandY = 1f; //control throw force of x and y direction

    [SerializeField]
    float throwForceInZ = 1f; //control throw force of z direction

    void Start()
    {
        //Keep ball floating until player can interact with it
        GetComponent<Rigidbody>().useGravity = false;
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
                    //TODO: Add force to y direction to give a thowing motion
                    GetComponent<Rigidbody>().AddForce(direction.x * throwForceInXandY,direction.y * throwForceInXandY, throwForceInZ/timeInterval);
                    GetComponent<Rigidbody>().useGravity = true;
                    break;
            }
        }
    }
}
