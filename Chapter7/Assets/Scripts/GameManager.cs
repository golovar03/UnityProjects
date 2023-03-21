using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _gameWinPanel;
    [SerializeField] private GameObject _musicManager;
    
    [SerializeField] private AudioSource _warriorsSound;
    [SerializeField] private AudioSource _farmsSound;

    [SerializeField] private ImageTimer _farmTimer;
    [SerializeField] private ImageTimer _eatingTimer;

    [SerializeField] private Image _raidTimerImg;
    [SerializeField] private Image _tomatoTimerImg;
    [SerializeField] private Image _securityTimerImg;

    [SerializeField] public Button _tomatoCreateButton;
    [SerializeField] public Button _securityCreateButton;

    [SerializeField] private Text _resourcesCount; //отображает общее количество ресурсов
    [SerializeField] private Text _countOfInfectedMen;
    [SerializeField] private Text _warriorsCountText;//..воинов
    [SerializeField] private Text _tomatoFarmsCountText;//..помидорных ферм
    [SerializeField] private Text _objectiveResources;
    [SerializeField] private Text _objectiveFarmsCount;
    [SerializeField] private Text _objectiveSecurityCount;
    [SerializeField] private Text _objectiveAttackCount;
    [SerializeField] private Text _timeToAttack;

    [SerializeField] private int _tomatoFarmsCount;//количество помидорных ферм
    [SerializeField] private int _securityCount; //количетсво воино "Охранник"
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
    private int _totalResource = 0;
    private int _totalSecurityCount = 0;
    private int _totalAttack = 0;

    private bool _objResourcesDone = false;
    private bool _objFarmsDone = false;
    private bool _objSecurityDone = false;
    private bool _objAttackDone = false;

    private Color _doneColor = new Color(0.14f, 1f, 0.25f, 1);
    private AudioController _musicController;

    void Start()
    {
        UpdateResourcesText();
        _musicController = _musicManager.GetComponent<AudioController>();
        _raidTimer = _raidMaxTime;
        Time.timeScale = 1;
    }
    void Update()
    {
        _raidTimer -= Time.deltaTime;
        _timeToAttack.text = "До следующей волны\n" + Mathf.Round(_raidTimer).ToString();
        _raidTimerImg.fillAmount = _raidTimer / _raidMaxTime;

        if (_raidTimer <= 0)
        {
            _raidMaxTime += 5;
            _raidTimer = _raidMaxTime;
            if ((_securityCount - _nextRaid) >= 0)
            {
                if (_nextRaid > 0)
                {
                    _totalAttack += 1;
                    if (_totalAttack == 10)
                    {
                        _objectiveAttackCount.color = _doneColor;
                        _objAttackDone = true;

                    }
                }
                _securityCount -= _nextRaid;
                _nextRaid += _raidIncrease;
                CheckWin();
            }
            else
            {
                GameLose();
            }
        }

        if (_farmTimer.Tick)
        {
            _tomatoCount += _tomatoFarmsCount * _tomatoProducesOneFarm;
            _totalResource += _tomatoFarmsCount * _tomatoProducesOneFarm;
            if (_totalResource >= 3000)
            {
                _objectiveResources.color = _doneColor;
                _objResourcesDone = true;
            }
        }

        if (_eatingTimer.Tick)
        {
            if ((_tomatoCount / _securityEatsTomato) < _securityCount)
            {
                _securityCount = _tomatoCount / _securityEatsTomato;
                _tomatoCount -= _securityCount * _securityEatsTomato;
            }
            else
            {
                _tomatoCount -= _securityCount * _securityEatsTomato;
            }
        }
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
            _farmsSound.Play();
            _tomatoFarmsCount += 1;
            if (_tomatoFarmsCount == _tomatoFarmsMaxCount)
            {
                _objectiveFarmsCount.color = _doneColor;
                _objFarmsDone = true;
                _tomatoCreateButton.interactable = false;
                _tomatoFarmsCountText.color = new Color(0.51f, 0.1f, 0.1f, 1);
            }
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
            _securityCount += 1;
            _warriorsSound.Play();
            _totalSecurityCount += 1;
            if (_totalSecurityCount == 50)
            {
                _objectiveSecurityCount.color = _doneColor;
                _objSecurityDone = true;
            }
        }
        UpdateResourcesText();
    }
    void UpdateResourcesText()
    {
        _resourcesCount.text = _tomatoCount.ToString();
        _objectiveResources.text = _totalResource.ToString() + "/3000";
        _warriorsCountText.text = _securityCount.ToString();
        _objectiveSecurityCount.text = _totalSecurityCount.ToString() + "/50";
        _tomatoFarmsCountText.text = _tomatoFarmsCount.ToString() + " / 6";
        _objectiveFarmsCount.text = _tomatoFarmsCount.ToString() + "/6";
        _objectiveAttackCount.text = _totalAttack.ToString() + "/10";
        _countOfInfectedMen.text = _nextRaid.ToString();
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
    }
    public void CreateSecurityWarrior()
    {
        if (_tomatoCount >= _tomatoPerBuySecurity)
        {
            _tomatoCount -= _tomatoPerBuySecurity;
            _securityCreateTimer = _securityCreateTime;
            _securityTimerImg.gameObject.SetActive(true);
            _securityCreateButton.interactable = false;
        }
    }
    public void WinGame()
    {
        _musicController.GameOverMusicPlay(true);
        Time.timeScale = 0;
        _gameWinPanel.SetActive(true);
    }
    public void GameLose()
    {
        _musicController.GameOverMusicPlay(false);
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);
    }
    public void CheckWin()
    {
        if (_objFarmsDone && _objResourcesDone && _objSecurityDone && _objAttackDone) 
        {
            WinGame();
        }
    }
}
