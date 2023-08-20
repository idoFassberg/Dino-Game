using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _confirmQuitButton;
    [SerializeField] private Button _closeQuitButton;
    [SerializeField] private GameObject _quitPanel;

    private void Awake()
    {
        _playButton.onClick.AddListener(StartGame);   
        _quitButton.onClick.AddListener(ShowQuitGame);   
        _confirmQuitButton.onClick.AddListener(QuitGame);
        _closeQuitButton.onClick.AddListener(CloseQuitGame);
        _quitPanel.SetActive(false);
    }

    private void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    private void ShowQuitGame()
    {
        _quitPanel.SetActive(true);
    }

    private void CloseQuitGame()
    {
        _quitPanel.SetActive(false);
    }
    
    private void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveListener(StartGame);   
        _quitButton.onClick.RemoveListener(ShowQuitGame);   
        _confirmQuitButton.onClick.RemoveListener(QuitGame);
        _closeQuitButton.onClick.RemoveListener(CloseQuitGame);   
    }
}
