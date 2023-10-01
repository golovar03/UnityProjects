using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    [SerializeField] private Transform platform;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float speed;

    private Vector3 _targetposition;

    private void Start()
    {
       _targetposition = endPoint.position;
    }

    void Update()
    {
        platform.position =  Vector3.MoveTowards(platform.position, _targetposition, Time.deltaTime * speed);
        
        if(Vector3.Distance(platform.position, _targetposition) < 0.01f)
        {
            if(_targetposition == endPoint.position)
            {
                _targetposition = startPoint.position;
            }
            else
            {
                _targetposition = endPoint.position;
            }
        }
    }
}
