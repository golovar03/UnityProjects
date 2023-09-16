using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : Bot
{
    
    void Start()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Superman superman = collision.gameObject.GetComponent<Superman>();
        if (superman)
        {
           SetDamage(superman.gameObject);
        }
        
    }
    public override void GetDamage()
    {
        Destroy(gameObject);
    }

    public override void SetDamage(GameObject gameObject)
    {
       Destroy(gameObject);
    }
}
