using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitMover _mover;
    [SerializeField] private UnitAnimator _animator;
    
    public PlayerType PlayerType {  get; private set; }

    public void Init(PlayerType playerType)
    {
        PlayerType = playerType;
    }
}