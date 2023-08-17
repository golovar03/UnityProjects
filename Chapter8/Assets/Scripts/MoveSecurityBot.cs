using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSecurityBot : MonoBehaviour
{
    [SerializeField] private Transform _securityBot;
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private bool _go;
    [SerializeField] private PatrolArea _areaPatrol;

    private Vector3 _target;

    void Start()
    {
        _securityBot.transform.position = _point1.position;
        _target = _point2.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_go)
        {
            Go();
        }
        if (_securityBot.transform.position == _target)
        {
            _go = false;
            _areaPatrol.StartPatrol();
            if (_target == _point1.position)
            {
                _target = _point2.position;
        
            }
            else
            {
                _target = _point1.position;
            }
            Go();
        }
    }

    public void Go()
    {
        _securityBot.transform.position = Vector3.MoveTowards(_securityBot.transform.position, _target, Time.deltaTime * 4);
        _securityBot.transform.LookAt(_target);
    }
}
