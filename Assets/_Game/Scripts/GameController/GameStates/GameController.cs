using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Game Date")]
    [SerializeField] private float _tapLimitDuration = 2.5f;

    [Header("Dependencies")]
    [SerializeField] public Unit _playerUnitPrefab;
    [SerializeField] public Transform _playerUnitSpawnLocation;
    [SerializeField] public UnitSpawner _unitSpawner;
    [SerializeField] public InputBroadcaster _input;

    public float TapLimitDuration => _tapLimitDuration;

    public Unit PlayerUnitPrefab => _playerUnitPrefab;
    public Transform PlayerUnitSpawnLocation => _playerUnitSpawnLocation;
    public UnitSpawner UnitSpawner => _unitSpawner;
    public InputBroadcaster Input => _input;
}
