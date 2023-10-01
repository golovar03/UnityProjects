using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultController : MonoBehaviour
{
    [SerializeField] private float catapultAngle = -50f;

    private HingeJoint joint;
    private JointSpring _startjointSpring;
    private JointSpring _kickjointSpring;

    void Start()
    {
        joint = GetComponent<HingeJoint>();
        _startjointSpring = joint.spring;
        _kickjointSpring = joint.spring;
        _kickjointSpring.targetPosition = catapultAngle;
    }

    public void Kick()
    {
        joint.spring = _kickjointSpring;      
    }

    public void StartPosition()
    {
        joint.spring = _startjointSpring;
    }
}
