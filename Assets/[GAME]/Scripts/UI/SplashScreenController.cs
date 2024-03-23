using UnityEngine;

public class SplashScreenController : MonoBehaviour
{
    public bool ScreenActive
    {
        set => gameObject.SetActive(value);
    }
}