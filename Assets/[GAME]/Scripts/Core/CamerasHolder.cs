using Cinemachine;
using UnityEngine;
using Zenject;

public class CamerasHolder : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _playerCamera;
    [SerializeField] private CinemachineBrain _brain;

    private IFollower _follower;

    public void Init()
    {
    }
}
