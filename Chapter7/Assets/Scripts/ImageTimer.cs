using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    public float MaxTime;
    public bool Tick;

    private Image _img;
    private float _currentTime;
    void Start()
    {
        _img = GetComponent<Image>();
        _currentTime = MaxTime;
    }

    
    void Update()
    {
        Tick = false;
        _currentTime -= Time.deltaTime;

        if(_currentTime <= 0)
        {
            Tick = true;
            _currentTime = MaxTime;
        }
        _img.fillAmount = _currentTime / MaxTime;
    }
}
