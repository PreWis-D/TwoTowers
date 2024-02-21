using UnityEngine;

public class AudioController
{
    private const int _audioOn = 1;
    private const int _audioOff = 0;

    private AudioData _audioData;

    public int CurrentAudioState { get; private set; }

    public AudioController()
    {
        _audioData = new AudioData();
        CurrentAudioState = _audioData.Load();

        ChangeListenerState(CurrentAudioState == _audioOn);
    }

    public void ChangeListenerState(bool isListenerOn)
    {
        CurrentAudioState = isListenerOn ? _audioOn : _audioOff;
        _audioData.Save(CurrentAudioState);

        ChangeVolume(isListenerOn);
    }

    public void ChangeVolume(bool isAudioOn)
    {
        if (CurrentAudioState == _audioOff) return;

        AudioListener.volume = isAudioOn ? _audioOn : _audioOff;
    }
}