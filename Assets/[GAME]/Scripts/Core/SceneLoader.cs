using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private SplashScreenController _splashScreenController;
    private const string _bootstrapScene = "Bootstrap";

    public SceneLoader(SplashScreenController splashScreenController)
    {
        _splashScreenController = splashScreenController;
    }

    public async UniTaskVoid LoadingScene(int index)
    {
        _splashScreenController.ScreenActive = true;

        var currentScene = SceneManager.GetActiveScene().name;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(_bootstrapScene));
 
        if(currentScene != _bootstrapScene)
        {
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(currentScene);

            while (!asyncUnload.isDone)
            {
                await UniTask.Yield();
            }
        }
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
 
        while (!asyncLoad.isDone)
        {
            await UniTask.Yield();
        }
        
        var newScene = SceneManager.GetSceneByBuildIndex(index);
        SceneManager.SetActiveScene(newScene);

        _splashScreenController.ScreenActive = false;
    }
}