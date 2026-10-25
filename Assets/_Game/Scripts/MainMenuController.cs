using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private UIDocument _document;
    private VisualElement _startMenuVisualTree;
    private Button _startButton;
    private Button _quitButton;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        // get menu sub object
        _startMenuVisualTree = _document.rootVisualElement.Q("StartMenuVisualTree");
        // assign button callbacks
        _startButton = _startMenuVisualTree.Q("StartButton") as Button;
        _quitButton = _startMenuVisualTree.Q("QuitButton") as Button;
    }

    private void OnEnable()
    {
        _startButton.RegisterCallback<ClickEvent>(OnStartButtonClick);
        _quitButton.RegisterCallback<ClickEvent>(OnQuitButtonClick);
    }

    private void OnDisable()
    {
        _startButton.UnregisterCallback<ClickEvent>(OnStartButtonClick);
        _quitButton.UnregisterCallback<ClickEvent>(OnQuitButtonClick);
    }

    private void OnStartButtonClick(ClickEvent evt)
    {
        Debug.Log("Start!");
        SceneManager.LoadScene("Gameplay");
    }

    private void OnQuitButtonClick(ClickEvent evt)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
