using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravitySphereScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody enteredBody = other.gameObject.GetComponent<Rigidbody>();
        if (enteredBody)
        {
            enteredBody.drag *= 1.5f;
            enteredBody.useGravity = false;
            Debug.Log(other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody enteredBody = other.gameObject.GetComponent<Rigidbody>();
        if (enteredBody)
        {
            enteredBody.drag /= 1.5f;
            enteredBody.useGravity = true;
        }
    }
}
