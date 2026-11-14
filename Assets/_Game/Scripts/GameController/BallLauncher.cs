using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private InputHandler _input;
    [SerializeField] private BallObject _ballObjectPrefab;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        //_input.TouchStarted += SpawnBall;
        _input.TouchEnded += InitializeBall;
    }

    private void OnDisable()
    {
        //_input.TouchStarted -= SpawnBall;
        _input.TouchEnded -= InitializeBall;
    }

    public void InitializeBall(Vector2 position)
    {
        Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(position);

        worldPosition.z = 0f;

        BallObject newBall = Instantiate(_ballObjectPrefab, worldPosition, Quaternion.identity);
    }
}
