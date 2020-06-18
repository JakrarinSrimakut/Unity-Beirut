using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticCupScript : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Ping Pong Ball")
        {
            Debug.Log("Ping Pong Ball Entered");
            //TODO: Score Point, Remove Cup, Reset ball
            col.GetComponent<PingPongScript>().Invoke("ResetBall", 1f);
        }
    }
}
