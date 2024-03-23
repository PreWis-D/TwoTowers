using UnityEngine;

[CreateAssetMenu(fileName = "CoreSettings", menuName = "Data/CoreSettings")]
public class CoreSettings : ScriptableObject
{
    private enum TargetFrameRate
    {
        Frame_Rate_30,
        Frame_Rate_60,
    }

    private const string _bootstrapScene = "Bootstrap";
    
    [Header("Target frame rate"), Space(10)]
    [SerializeField] private TargetFrameRate _frameRate;

    [Header("Debug settings"), Space(10)]
    [SerializeField,] private bool _fpsCounterEnabled;
    [SerializeField] private GameObject _fpsCounter;

    [Header("Screen sleep")] 
    [SerializeField] private bool _enableSleep;
    
    public int TargetFrameRateValue => _frameRate == TargetFrameRate.Frame_Rate_30 ? 30 : 60;
    public bool FpsCounterEnabled => _fpsCounterEnabled;
    public bool EnableSleep => _enableSleep;
    public GameObject FpsCounter => _fpsCounter;
    public string BootstrapScene => _bootstrapScene;
    public bool IsCoreStart { get; set; }
}