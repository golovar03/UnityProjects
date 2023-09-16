using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float supermanSpeed = 10f;

    private float _sideForce;
    private float _forwardForse;
    private Rigidbody _superman;
    void Start()
    {
        _superman = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void GetDamage()
    {
       Destroy(gameObject);   
    }

    public void Move()
    {
        _sideForce = Input.GetAxis("Horizontal") * supermanSpeed;
        _forwardForse = Input.GetAxis("Vertical") * supermanSpeed;
        _superman.AddForce(-_sideForce, 0f, -_forwardForse);
    }
}
