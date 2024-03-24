using System;
using UnityEngine;

public abstract class BaseTower : MonoBehaviour
{
    public DamageHandler DamageHandler { get; private set; }
    public PlayerType PlayerType {  get; private set; }

    public void Init(int health, PlayerType playerType)
    {
        DamageHandler = new DamageHandler(health);
        PlayerType = playerType;
    }
}