using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    [SerializeField] private Propeller tubePropeller;

    private float _upPower;

    private void Update()
    {
        _upPower = tubePropeller.GetUpPower() / 6;
    }

    private void OnTriggerEnter(Collider other)
    {
        OnWind();
    }

    private void OnTriggerStay(Collider other)
    {
        OnWind();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    public void OnWind()
    {
        Collider[] inTriggerColls = Physics.OverlapBox(transform.position, transform.localScale);
        for (int i = 0; i < inTriggerColls.Length; i++)
        {
            Rigidbody rigidbody = inTriggerColls[i].attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(_upPower, transform.position, transform.localScale.y);
            }
        }
    }
}
