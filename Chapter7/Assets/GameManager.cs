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
    [SerializeField] private Text _TomatoFarmsCountText;

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

    private float _TomatoFarmTimer = -2;
    private float _WarriorCreateTimer = -4;
    private int _TomatoFarmsMaxCount = 6;





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
        }

        if (_EatingTimer.Tick)
        {
            _TomatoCount -= _WarriorsCount * _WarriorEatsTomato;
        }
        UpdateResourcesText();

        if (_TomatoFarmTimer > 0)
        {
            _TomatoFarmTimer -= Time.deltaTime;
            _TomatoTimer.fillAmount = _TomatoFarmTimer / _TomatoFarmCreateTime;
        }
        else if (_TomatoFarmTimer >= -1)
        {
            _TomatoTimer.fillAmount = 1;
            _TomatoFarmTimer = -2;
            _TomatoButton.interactable = true;
            _TomatoTimer.gameObject.SetActive(false);
            _TomatoFarmsCount += 1;
        }
    }

    void UpdateResourcesText()
    {
        _ResourcesCount.text = _TomatoCount.ToString();
        _WarriorsCountText.text = _WarriorsCount.ToString();
        _TomatoFarmsCountText.text = _TomatoFarmsCount.ToString();
    }

    public void CreateTomatoFarm()
    {
        _TomatoCount -= _TomatoPerBuyFarm;
        if (_TomatoCount >= 0 && _TomatoFarmsCount < _TomatoFarmsMaxCount)
        {
            _TomatoFarmTimer = _TomatoFarmCreateTime;
            _TomatoTimer.gameObject.SetActive(true);
            _TomatoButton.interactable = false;
        }
        else if(_TomatoFarmsCount == _TomatoFarmsMaxCount)
        {
            _TomatoButton.interactable = false;
        }
    }
}
