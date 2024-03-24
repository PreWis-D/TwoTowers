using UnityEngine;

public class LevelData : ISaveLoadService
{
    private const string _currentLevelSave = "CurrentLevelSave";

    public int Load()
    {
        return PlayerPrefs.GetInt(_currentLevelSave, 1);
    }

    public void Save(int stateValue)
    {
        PlayerPrefs.SetInt(_currentLevelSave, stateValue);
    }
}
