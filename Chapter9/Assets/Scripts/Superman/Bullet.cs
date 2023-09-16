using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _bulletLife = 5f;

    private void FixedUpdate()
    {
        _bulletLife -= Time.fixedDeltaTime;
        if (_bulletLife <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Superman superman = collision.gameObject.GetComponent<Superman>();
        Friend friend = collision.gameObject.GetComponent<Friend>();

        if (superman)
        {
            superman.GetDamage();
            Destroy(gameObject);
        }
        else if (friend)
        {
            friend.GetDamage();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GetComponent<Rigidbody>().drag = 0f;
        GetComponent<Rigidbody>().angularDrag = 0f;
        GetComponent<Rigidbody>().velocity = Vector3.down * 30f;
    }
}
