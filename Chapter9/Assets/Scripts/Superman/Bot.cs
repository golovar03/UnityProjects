using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class Bot : MonoBehaviour
{
    
    [SerializeField] private Transform[] spots;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform bot;
    private int _spot = 0;
    private int _forward = 1;

    void Start()
    {
        bot = GetComponent<Transform>();
    }

    public virtual void SetStartPosition()
    {
        if (spots.Length > 1)
        {
            bot.transform.position = spots[0].position;
            bot.transform.LookAt(spots[1].position);
        }
    }

    public virtual void Move()
    {
        bot.position = Vector3.MoveTowards(bot.position, spots[_spot].position, Time.deltaTime * moveSpeed);

        if (Vector3.Distance(bot.position, spots[_spot].position) < 0.2f)
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
            bot.transform.LookAt(spots[_spot].position);
        }
    }

    public virtual void GetDamage()
    {

    }

    public virtual void SetDamage(GameObject gameObject)
    {
        
    }
}
