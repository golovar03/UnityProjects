using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Bot
{

    void Start()
    {
        SetStartPosition();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public override void GetDamage()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
       Superman superman = collision.gameObject.GetComponent<Superman>();
        if (superman != null)
        {
            GetDamage();
        }
    }
}
