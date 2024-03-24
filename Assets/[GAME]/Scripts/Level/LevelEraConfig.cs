using UnityEngine;

[CreateAssetMenu(fileName = "LevelEraConfig", menuName = "Configs/LevelEraConfig")]
public class LevelEraConfig : ScriptableObject
{
    [SerializeField] private EraPropirties[] _unitsPacks;


    public EraPropirties[] UnitsPacks => _unitsPacks;
}