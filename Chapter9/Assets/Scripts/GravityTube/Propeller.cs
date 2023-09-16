using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    [SerializeField] private Rigidbody propellerRB;
    [SerializeField] private float propellerTorquePower = 10f;

    private float _upForcePower;
    void Start()
    {
        _upForcePower = propellerTorquePower;
        propellerRB.maxAngularVelocity = 100;
    }

    void Update()
    {
        propellerRB.AddTorque(0, propellerTorquePower, 0);
        _upForcePower = propellerRB.angularVelocity.y;
    }

    public float GetUpPower()
    {
        return Mathf.Abs(_upForcePower);
    }
}
