using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    public Transform Robot;
   
    public Transform point1;
    public Transform point2;
    private Vector3 _target;
    public bool Go;

    void Start()
    {
        Robot.transform.position = point1.position;
        _target = point2.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Go)
        {
            Robot.transform.position = Vector3.MoveTowards(Robot.transform.position, _target, Time.deltaTime * 3);
            Robot.transform.LookAt(_target);
        }
        
        if (Robot.transform.position == _target)
        {
            if(_target == point1.position)
            {
                _target = point2.position;
            }
            else
            {
                _target = point1.position;
            }
        }      
    }
}
