using UnityEngine;

[CreateAssetMenu(fileName = "BallData_", menuName = "BallData")]
public class BallsData : ScriptableObject
{
    [field: SerializeField] public Sprite Visuals { get; private set; }
    [field: SerializeField] public string Name { get; private set; } = "default";
    [field: SerializeField] public float Damage { get; private set; } = 3;
}
