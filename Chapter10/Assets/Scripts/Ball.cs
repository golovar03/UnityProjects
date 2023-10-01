using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CatapultController catapult = other.GetComponentInParent<CatapultController>();
        if (catapult)
        {
            catapult.Kick();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CatapultController catapult = other.GetComponentInParent<CatapultController>();
        if(catapult)
        {
            catapult.StartPosition();
        }    
    }
}
