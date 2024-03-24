using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : ISaveLoadService
{
    private const string _currentPlayerEraSave = "CurrentPlayerEraSave";
    private const string _currentPlayerStageSave = "CurrentPlayerStageSave";
    private const string _currentPlayerDurationSave = "CurrentPlayerDurationSave";

    public int Load()
    {
        return PlayerPrefs.GetInt(_currentPlayerEraSave, 1);
    }

    public int LoadStage()
    {
        return PlayerPrefs.GetInt(_currentPlayerStageSave, 3);
    }

    public float LoadDuration()
    {
        return PlayerPrefs.GetFloat(_currentPlayerDurationSave, 5);
    }

    public void Save(int value)
    {
        PlayerPrefs.SetInt(_currentPlayerEraSave, value);
    }

    public void SaveStage(int value)
    {
        PlayerPrefs.SetInt(_currentPlayerStageSave, value);
    }

    public void SaveDuration(float value)
    {
        PlayerPrefs.SetFloat(_currentPlayerDurationSave, value);
    }
}