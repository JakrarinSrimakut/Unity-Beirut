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
        //Check if player is touching ball


    }
}
