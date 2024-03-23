using UnityEngine;

public class AudioData : ISaveLoadService
{
    private const string _saveAudioState = "SaveAudioState";

    public int Load()
    {
        return PlayerPrefs.GetInt(_saveAudioState, 1);
    }

    public void Save(int stateValue)
    {
        PlayerPrefs.SetInt(_saveAudioState, stateValue);
    }
}
