using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolArea : MonoBehaviour
{
    [SerializeField] private Transform[] targets = new Transform[4];
    [SerializeField] private Transform _head;

    void Start()
    {
        
    }
    
    public void StartPatrol()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            _head.transform.LookAt(targets[i]);
            Debug.Log("Смотрю на точку:", targets[i]);
        }   
    }
}
