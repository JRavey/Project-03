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

    private void Start()
    {
        DisableAllDisplays();
    }
    private void DisableAllDisplays()
    {
        _endMenuVisualTree.style.display = DisplayStyle.None;
    }

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        // get menu sub object
        _endMenuVisualTree = _document.rootVisualElement.Q("GameEndedMenuVisualTree");
        // assign button callbacks
        _retryButton = _endMenuVisualTree.Q("RetryButton") as Button;
        _toMainMenuButton = _endMenuVisualTree.Q("MainMenuButton") as Button;
    }

    private void OnEnable()
    {
        _retryButton.RegisterCallback<ClickEvent>(OnRetryButtonClick);
        _toMainMenuButton.RegisterCallback<ClickEvent>(OnMainMenuButtonClick);
    }

    private void OnDisable()
    {
        _retryButton.UnregisterCallback<ClickEvent>(OnRetryButtonClick);
        _toMainMenuButton.UnregisterCallback<ClickEvent>(OnMainMenuButtonClick);
    }

    public void DisplayGameEndedMenu()
    {
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
}
