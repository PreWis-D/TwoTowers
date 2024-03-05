using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class JoystickInput : MonoBehaviour, IInput
{
    [SerializeField, Min(0)] private int _limitOffsetStickImage;
    [SerializeField, Min(0)] private int _limitDirection = 2;
    [SerializeField, Min(0)] private float _speedStickImage;
    [SerializeField, Range(0f, 1f)] private float _sensitivity;

    private PlayerInput _playerInput;
    private Image _circleImage;
    private Image _stickImage;
    private RectTransform _rectCircle;
    private RectTransform _rectStick;
    private Vector3 _direction;
    private Vector3 _initialTouch;
    private float _magnitude;

    public float CameraAngle { get; private set; }
    public bool IsTouch { get; private set; }

    public float LimitOffsetStickImage => _limitOffsetStickImage;
    public float Magnitude => _magnitude;
    public Vector3 Direction => new Vector3(_direction.x, _direction.y, 0f);


    public event Action OnTouchDownEvent;
    public event Action OnTouchReleasedEvent;

    [Inject]
    private void Construct(PlayerInput playerInput)
    {
        _rectCircle = GetComponent<RectTransform>();
        _circleImage = transform.GetComponent<Image>();
        _rectStick = transform.GetChild(0).GetComponent<RectTransform>();
        _stickImage = transform.GetChild(0).GetComponent<Image>();
        _playerInput = playerInput;

        Reset();
    }

    private void StartInput()
    {
        IsTouch = true;

        _initialTouch = _playerInput.Player.TouchPosition.ReadValue<Vector2>();
        _rectCircle.position = _initialTouch;
        _rectStick.position = _initialTouch;
        _circleImage.enabled = true;
        _stickImage.enabled = true;
        
        OnTouchDownEvent?.Invoke();
    }

    private void PerformedInput()
    {
        
        var touch = _playerInput.Player.TouchPosition.ReadValue<Vector2>();
        var touchDirection = Vector3.ClampMagnitude((Vector3)touch - _rectCircle.position, _limitDirection) * _sensitivity;
        var touchOffset = Vector3.ClampMagnitude((Vector3)touch - _rectCircle.position, _limitOffsetStickImage);
        _magnitude = touchOffset.magnitude;
        _rectStick.anchoredPosition = Vector2.Lerp(_rectStick.anchoredPosition, touchOffset, Time.deltaTime * _speedStickImage);
        _direction = Vector2.Lerp(_direction, touchOffset / _limitOffsetStickImage, Time.deltaTime * _speedStickImage);
    }

    private void EndInput()
    {
        Reset();
        
        OnTouchReleasedEvent?.Invoke();
    }

    private void Update()
    {
        if (_playerInput.Player.Touch.WasPressedThisFrame())
        {
            if(EventSystem.current.IsPointerOverGameObject(-1)) return;
            StartInput();
        }
        
        if (_playerInput.Player.Touch.WasReleasedThisFrame())
        {
            EndInput();
        }

        if (IsTouch)
        {
            PerformedInput();
        }    
    }

    private void Reset()
    {
        IsTouch = false;
        
        _direction = Vector2.zero;
        
        if (!_circleImage || !_stickImage) return;
        
        _circleImage.enabled = false;
        _stickImage.enabled = false;
    }
    
    private void OnDisable()
    {
        Reset();
    }
}