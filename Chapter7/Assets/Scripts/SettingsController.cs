using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SettingsController : MonoBehaviour
{
    public Settings audioSettings;
    public void LoadSettings()
    {
        audioSettings = JsonUtility.FromJson<Settings>(File.ReadAllText(Application.streamingAssetsPath + "/Settings.json"));
    }
    public void SaveSettings()
    {
        File.WriteAllText(Application.streamingAssetsPath + "/Settings.json", JsonUtility.ToJson(audioSettings));
    }
    public void OnOffMusic()
    {
        if (audioSettings.MusicOn)
        {
            audioSettings.MusicOn = false;
        }
        else
        {
            audioSettings.MusicOn = true;
        }
    }
    public void OnOffSound()
    {
        if (audioSettings.SoundOn)
        {
            audioSettings.SoundOn = false;
        }
        else
        {
            audioSettings.SoundOn = true;
        }
    }

    [System.Serializable]
    public class Settings
    {
        public bool SoundOn;
        public bool MusicOn;
    }


}
