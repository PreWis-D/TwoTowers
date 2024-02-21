using Zenject;

public class Level
{
    private AudioController _controller;

    [Inject]
    public void Construct(AudioController audioController)
    {
        _controller = audioController;
    }

    public void Init()
    {
        
    }
}