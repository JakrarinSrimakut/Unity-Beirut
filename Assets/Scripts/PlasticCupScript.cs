using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticCupScript : MonoBehaviour
{
    Collider col;
    void OnTriggerEnter(Collider col)
    {
        this.col = col;

        if(col.tag == "Ping Pong Ball")
        {
            Debug.Log("Ping Pong Ball Entered");
            //TODO: Score Point
            Invoke("ResetRound", 3);
        }
    }

    void ResetRound()
    {
        col.GetComponent<PingPongScript>().setBallInCupTrue();
        col.GetComponent<PingPongScript>().ResetBall();
        Destroy(gameObject);//remove cup
    }
}
