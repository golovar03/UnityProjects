using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawner : MonoBehaviour
{
    [SerializeField] private float power = 120f;

    private Rigidbody _jumperRb;

    private void Awake()
    {
        _jumperRb = GetComponent<Rigidbody>();
        Collider jumperColl = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball)
        {
            OnKick(power);
        }
    }
    private void OnKick(float power)
    {
        _jumperRb.AddForce(new Vector3(0f, 0f, power), ForceMode.Impulse);      
    }
}
