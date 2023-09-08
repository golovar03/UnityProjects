using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolSecurityBot : MonoBehaviour
{
    [SerializeField] private Transform securityBot;
    [SerializeField] private Transform[] spots;
    [SerializeField] private float moveSpeed;

    private int _spot = 0;
    private int _forward = 1;

    void Start()
    {
        if (spots.Length > 1)
        {
            securityBot.transform.position = spots[0].position;
            securityBot.transform.LookAt(spots[1].position);
        }
    }

    void Update()
    {
        securityBot.position = Vector3.MoveTowards(securityBot.position, spots[_spot].position, Time.deltaTime * moveSpeed);

        if (Vector3.Distance(securityBot.position, spots[_spot].position) < 0.2f)
        {
            if (_spot == spots.Length - 1)
            {
                _forward = -1;
            }

            if (_spot == 0)
            {
                _forward = 1;
            }

            _spot += _forward;
            securityBot.transform.LookAt(spots[_spot].position);
        }
    }
}
