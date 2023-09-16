using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 200f;
    [SerializeField] private float shootTimer = 5f;

    private float _currentTimer;

    void Start()
    {
        _currentTimer = shootTimer;  
    }

    void Update()
    {
        if(_currentTimer <= 0)
        {
            Shoot();
            _currentTimer = shootTimer;
        }
        _currentTimer -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        Debug.Log("Ïטפ!");    
    } 
}
