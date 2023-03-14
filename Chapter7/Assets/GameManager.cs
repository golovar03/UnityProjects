using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ImageTimer _FarmTimer;
    [SerializeField] private ImageTimer _EatingTimer;

    [SerializeField] private Image _RaidTimer;
    [SerializeField] private Image _TomatoTimer;
    [SerializeField] private Image _WarriorsTimer;

    [SerializeField] private Button _TomatoButton;
    [SerializeField] private Button _WarriorsButton;
    
    [SerializeField] private Text _ResourcesCount;
    [SerializeField] private Text _WarriorsCountText;
    [SerializeField] private int _TomatoFarmsCount;
    [SerializeField] private int _WarriorsCount;
    [SerializeField] private int _TomatoCount;
    [SerializeField] private int _TomatoProducesOneFarm;
    [SerializeField] private int _WarriorEatsTomato;
    [SerializeField] private int _TomatoPerBuyFarm;
    [SerializeField] private int _TomatoPerBuyWarrior;
    [SerializeField] private int _TomatoFarmCreateTime;
    [SerializeField] private int _WarriorCreateTime;
    [SerializeField] private int _RaidMaxTime;
    [SerializeField] private int _RaidIncrease;
    [SerializeField] private int _NextRaid;





    void Start()
    {
        UpdateResourcesText(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (_FarmTimer.Tick)
        {
            _TomatoCount += _TomatoFarmsCount * _TomatoProducesOneFarm;
            UpdateResourcesText();
        }

        if (_EatingTimer.Tick)
        {
            _TomatoCount -= _WarriorsCount * _WarriorEatsTomato;
            UpdateResourcesText();
        }
    }

    void UpdateResourcesText()
    {
        _ResourcesCount.text = _TomatoCount.ToString();
        _WarriorsCountText.text = _WarriorsCount.ToString();
    }
}
