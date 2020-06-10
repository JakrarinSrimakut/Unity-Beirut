using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongScript : MonoBehaviour
{
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
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, GetComponent<Transform>().position.z));

            //Check if player touching ball
            Debug.Log(touchPos.x + "," + touchPos.y + "," + touchPos.z);
        }

    }
}
