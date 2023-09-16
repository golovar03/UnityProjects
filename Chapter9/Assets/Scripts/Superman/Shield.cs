using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private float shieldPower = 100f;

    public float GetDamage()
    {
        shieldPower -= 50f;
        if (shieldPower <= 0)
        {
            Destroy(gameObject);
        }
        return shieldPower;
    }
}
