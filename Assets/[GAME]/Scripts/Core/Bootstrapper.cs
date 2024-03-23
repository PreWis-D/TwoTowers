using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private SplashScreenController _splashScreen;

    private CoreSettings _coreSettings;
    private SceneLoader _sceneLoader;

    private void Awake()
    {
        _sceneLoader = new SceneLoader(_splashScreen);
    }

    private void Start()
    {
        LoadGame().Forget();
    }

    private async UniTaskVoid LoadGame()
    {
        _coreSettings = Resources.Load("CoreSettings") as CoreSettings;

        Debug.Log(_coreSettings.IsCoreStart + " check core start");
        _splashScreen.ScreenActive = _coreSettings.IsCoreStart;

        Application.targetFrameRate = _coreSettings.TargetFrameRateValue;
        Screen.sleepTimeout = _coreSettings.EnableSleep ? SleepTimeout.SystemSetting : SleepTimeout.NeverSleep;

        if (_coreSettings.FpsCounterEnabled)
            Instantiate(_coreSettings.FpsCounter);

        await UniTask.Delay(100);

        if (_coreSettings.IsCoreStart)
        {
            int buildIndex = SceneManager.GetActiveScene().buildIndex + 1;
            Debug.Log(buildIndex + " load");
            _sceneLoader.LoadingScene(buildIndex).Forget();
        }

        Destroy(this.gameObject);
    }
}