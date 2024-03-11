using UnityEngine;
using Zenject;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Transform _inputContainer;

    [Inject]
    private void Construct(IInput input)
    {
        var joystick = input as JoystickInput;
        if (joystick) joystick.transform.SetParent(_inputContainer.transform);
    }
}
