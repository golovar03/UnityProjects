using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    [SerializeField] private Transform robot;

    [SerializeField] internal Transform point1;
    [SerializeField] internal Transform point2;
    [SerializeField] private float moveSpeed;

    internal bool Go;
    private Vector3 _target;


    void Start()
    {
        robot.transform.position = point1.position;
        _target = point2.position;
    }

    void Update()
    {
        if ((robot.transform.childCount == 1 & robot.transform.position == point2.position) ||
            (robot.transform.childCount == 0 & robot.transform.position == point1.position))
        {
            Go = false;
        }
        else
        {
            Go = true;
        }

        if (Go == true)
        {
            robot.transform.position = Vector3.MoveTowards(robot.transform.position, _target, Time.deltaTime * moveSpeed);
            robot.transform.LookAt(_target);
            if (robot.transform.position == _target)
            {
                if (_target == point1.position)
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
}
