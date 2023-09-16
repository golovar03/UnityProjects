using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullKick : MonoBehaviour
{
    [SerializeField] private float Power = 5;
    [SerializeField] private bool isKicked = false;

    private Rigidbody _whiteBall;

    private void Awake()
    {
        _whiteBall = GetComponent<Rigidbody>();
    }

    private void Kick()
    {
        _whiteBall.AddForce(0f, 0f, -5f * Power, ForceMode.VelocityChange);   
    }

    private void Update()
    {
        if(isKicked)
        {
            Kick();
            isKicked=false;
        }
    }
}
