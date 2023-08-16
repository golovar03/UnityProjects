using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip _loseSound;
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private AudioSource _music;

    //[SerializeField] private Image _sounds;
    //[SerializeField] private Image _musicImg;
    
    //[SerializeField] private Sprite _onSprite;
    //[SerializeField] private Sprite _offSprite;

    private AudioSource _clickSound;
    //private AudioSource _backgroundMusic;

    private SettingsController _audioSettings;
     
    private float _savedMusicVolume;
    private float _savedClickVolume;
    void Start()
    {
        _clickSound = GetComponent<AudioSource>();
        _audioSettings = GetComponent<SettingsController>();
        _savedClickVolume = _clickSound.volume;
        _savedMusicVolume = _music.volume;
        _audioSettings.LoadSettings();
        ChangeLoadedSettings();
        _music.Play();

    }

    public void ClickMenuButton()
    {
        if (_audioSettings.audioSettings.SoundOn == true)
        {
            _clickSound.volume = _savedClickVolume;
        }
        else
        {
            _clickSound.volume = 0f;
        }
        _clickSound.Play();
    }

    public void OnOffMusic()
    {
        if(_music.volume > 0f)
        {
            _music.volume = 0f;
        }
        else
        {
            _music.volume = _savedMusicVolume;
        }
        _audioSettings.OnOffMusic();
    }

    public void OnOffSounds()
    {
        if(_clickSound.volume > 0f)
        {
            _clickSound.volume = 0f;    
        }
        else
        {
            _clickSound.volume = _savedClickVolume;
        }
        _audioSettings.OnOffSound();
    }

    public void BackgroundMusicPlay()
    {
        _music.Play();
    }

    public void GameOverMusicPlay(bool winGame)
    {
        if (winGame)
        {
            _music.clip = _winSound;
        }
        else
        {
            _music.clip = _loseSound;
        }
        _music.loop = false;
        BackgroundMusicPlay();
    }

    public void ChangeLoadedSettings()
    {
        if (_audioSettings.audioSettings.MusicOn == false)
        {
            _music.volume = 0f;
        }
        else
        {
            _music.volume = _savedMusicVolume;
        }
        if (_audioSettings.audioSettings.SoundOn == false)
        {
            _clickSound.volume = 0f;
        }
        else
        {
            _clickSound.volume = _savedMusicVolume;
        }
    }

    public void ClickCloseSettings()
    {
        _audioSettings.SaveSettings();
    }
}
