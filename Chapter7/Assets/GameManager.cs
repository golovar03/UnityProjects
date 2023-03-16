using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private ImageTimer _farmTimer;
    [SerializeField] private ImageTimer _eatingTimer;

    [SerializeField] private Image _raidTimerImg;
    [SerializeField] private Image _tomatoTimerImg;
    [SerializeField] private Image _securityTimerImg;

    [SerializeField] private Button _tomatoCreateButton;
    [SerializeField] private Button _securityCreateButton;
    
    [SerializeField] private Text _resourcesCount; //отображает общее количество ресурсов
    [SerializeField] private Text _warriorsCountText;//..воинов
    [SerializeField] private Text _tomatoFarmsCountText;//..помидрных ферм

    [SerializeField] private int _tomatoFarmsCount;//количество помидорных ферм
    [SerializeField] private int _securutyCount; //количетсво воино "Охранник"
    [SerializeField] private int _tomatoCount; //количество помидоров
    [SerializeField] private int _tomatoProducesOneFarm; //количетсво помидоров, производимых одной фермой за цикл
    [SerializeField] private int _securityEatsTomato; //съедает помидор Охранник за цикл
    [SerializeField] private int _tomatoPerBuyFarm; //количетсво помидор на покупку новой фермы
    [SerializeField] private int _tomatoPerBuySecurity; //количество помидор на найм Охранника
    [SerializeField] private int _tomatoFarmCreateTime; //время постройки фермы (сек.)
    [SerializeField] private int _securityCreateTime; //время найма Охраниика (сек.)
    [SerializeField] private int _raidMaxTime; //время до нападения (сек.)
    [SerializeField] private int _raidIncrease; //количество зомби на которое увеличивается каждое новое нападение
    [SerializeField] private int _nextRaid; //

    private float _tomatoFarmTimer = -2;
    private float _securityCreateTimer = -2;
    private float _raidTimer;
    private int _tomatoFarmsMaxCount = 6;





    void Start()
    {
        UpdateResourcesText();
        _raidTimer = _raidMaxTime;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _raidTimer -= Time.deltaTime;
        _raidTimerImg.fillAmount = _raidTimer / _raidMaxTime;

        if(_raidTimer <= 0)
        {
            _raidTimer = _raidMaxTime;
            if((_securutyCount -= _nextRaid) >= 0)
            {
                _securutyCount -= _nextRaid;
                _nextRaid += _raidIncrease;
            }
            else
            {
                Time.timeScale = 0;
                _gameOverPanel.SetActive(true);
            }
            
        }

        if (_farmTimer.Tick)
        {
            _tomatoCount += _tomatoFarmsCount * _tomatoProducesOneFarm;
        }

        if (_eatingTimer.Tick)
        {
            if ((_tomatoCount / _securityEatsTomato) < _securutyCount)
            {
                _securutyCount = _tomatoCount / _securityEatsTomato;
                _tomatoCount -= _securutyCount * _securityEatsTomato;
            }
            else
            {
                _tomatoCount -= _securutyCount * _securityEatsTomato;
            }
        }
        UpdateResourcesText();

        if (_tomatoFarmTimer > 0)
        {
            _tomatoFarmTimer -= Time.deltaTime;
            _tomatoTimerImg.fillAmount = _tomatoFarmTimer / _tomatoFarmCreateTime;
        }
        else if (_tomatoFarmTimer >= -1)
        {
            _tomatoTimerImg.fillAmount = 1;
            _tomatoFarmTimer = -2;
            _tomatoCreateButton.interactable = true;
            _tomatoTimerImg.gameObject.SetActive(false);
            _tomatoFarmsCount += 1;
        }

        if (_securityCreateTimer > 0)
        {
            _securityCreateTimer -= Time.deltaTime;
            _securityTimerImg.fillAmount = _securityCreateTimer / _securityCreateTime;
        }
        else if (_securityCreateTimer >= -1)
        {
            _securityTimerImg.fillAmount = 1;
            _securityCreateTimer = -2;
            _securityTimerImg.gameObject.SetActive(false);
            _securityCreateButton.interactable = true;
            _securutyCount += 1;
        }
    }

    void UpdateResourcesText()
    {
        _resourcesCount.text = _tomatoCount.ToString();
        _warriorsCountText.text = _securutyCount.ToString();
        _tomatoFarmsCountText.text = _tomatoFarmsCount.ToString();
    }

    public void CreateTomatoFarm()
    {
        if (_tomatoCount >= _tomatoPerBuyFarm && _tomatoFarmsCount < _tomatoFarmsMaxCount)
        {
            _tomatoCount -= _tomatoPerBuyFarm;
            _tomatoFarmTimer = _tomatoFarmCreateTime;
            _tomatoTimerImg.gameObject.SetActive(true);
            _tomatoCreateButton.interactable = false;
        }
        else if(_tomatoFarmsCount == _tomatoFarmsMaxCount)
        {
            _tomatoCreateButton.interactable = false;
        }
    }

    public void CreateSecurityWarrior()
    {
        if(_tomatoCount >= _tomatoPerBuySecurity)
        {
            _tomatoCount -= _tomatoPerBuySecurity;
            _securityCreateTimer = _securityCreateTime;
            _securityTimerImg.gameObject.SetActive(true);
            _securityCreateButton.interactable = false;
        }
    }
}
