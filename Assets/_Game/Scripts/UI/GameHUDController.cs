using UnityEngine;
using UnityEngine.UIElements;

public class GameHUDController : MonoBehaviour
{
    [SerializeField] private GameController _gameController;

    private UIDocument _document;

    // End Screen UI
    private VisualElement _endMenuVisualTree;
    private Button _retryButton;
    private Button _toMainMenuButton;
    private Label _endScore;
    private Label _highScore;

    // Game HUD
    private VisualElement _gameplayHUDVisualTree;
    private Label _score;
    private ListView _ballView;

    private void Start()
    {
        DisableAllDisplays();
        _gameplayHUDVisualTree.style.display = DisplayStyle.Flex;
    }
    private void DisableAllDisplays()
    {
        _endMenuVisualTree.style.display = DisplayStyle.None;
        _gameplayHUDVisualTree.style.display = DisplayStyle.None;
    }

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        // get menu sub object
        _endMenuVisualTree = _document.rootVisualElement.Q("GameEndedMenuVisualTree");
        _gameplayHUDVisualTree = _document.rootVisualElement.Q("HUD");
        // assign button callbacks
        _retryButton = _endMenuVisualTree.Q("RetryButton") as Button;
        _toMainMenuButton = _endMenuVisualTree.Q("MainMenuButton") as Button;
        _endScore = _endMenuVisualTree.Q("EndScore") as Label;
        _highScore = _endMenuVisualTree.Q("HighScore") as Label;

        _ballView = _gameplayHUDVisualTree.Q("BallView") as ListView;
        _score = _gameplayHUDVisualTree.Q("Score") as Label;

        _ballView.makeItem = () => new Image();
        _ballView.bindItem = (VisualElement element, int index) =>
        {
            (element as Image).sprite = _gameController.BallManager.gameBalls[index]._data.Visuals;
        };
        _ballView.itemsSource = _gameController.BallManager.gameBalls;
        _ballView.Rebuild();
    }

    private void OnEnable()
    {
        _retryButton.RegisterCallback<ClickEvent>(OnRetryButtonClick);
        _toMainMenuButton.RegisterCallback<ClickEvent>(OnMainMenuButtonClick);

        GameScore.OnScored += UpdateScoreDisplay;
    }

    private void OnDisable()
    {
        _retryButton.UnregisterCallback<ClickEvent>(OnRetryButtonClick);
        _toMainMenuButton.UnregisterCallback<ClickEvent>(OnMainMenuButtonClick);

        GameScore.OnScored -= UpdateScoreDisplay;
    }

    public void DisplayGameEndedMenu()
    {
        DisableAllDisplays();
        _endMenuVisualTree.style.display = DisplayStyle.Flex;
    }

    private void OnRetryButtonClick(ClickEvent evt)
    {
        Debug.Log("Retry Level");
        _gameController.ReloadLevel();
    }

    private void OnMainMenuButtonClick(ClickEvent evt)
    {
        Debug.Log("To Main Menu");
        _gameController.LoadLevel("MainMenu");
    }

    private void UpdateScoreDisplay(int newScore)
    {
        _score.text = "Score: " + newScore;
    }

    public void UpdateEndScore(int newScore)
    {
        _endScore.text = "Your Score: " + newScore;
    }

    public void UpdateHighScore(int newScore)
    {
        _highScore.text = "High Score: " + newScore;
    }
}
