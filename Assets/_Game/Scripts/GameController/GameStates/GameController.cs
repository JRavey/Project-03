using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Game Date")]
    [SerializeField] private float _tapLimitDuration = 2.5f;

    [Header("Dependencies")]
    [SerializeField] public Unit _playerUnitPrefab;
    [SerializeField] public Transform _playerUnitSpawnLocation;
    [SerializeField] public UnitSpawner _unitSpawner;
    [SerializeField] public InputBroadcaster _input;
    [SerializeField] public GameHUDController _gameHUDController;

    public float TapLimitDuration => _tapLimitDuration;

    public Unit PlayerUnitPrefab => _playerUnitPrefab;
    public Transform PlayerUnitSpawnLocation => _playerUnitSpawnLocation;
    public UnitSpawner UnitSpawner => _unitSpawner;
    public InputBroadcaster Input => _input;
    public GameHUDController GameHUDController => _gameHUDController;

    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
