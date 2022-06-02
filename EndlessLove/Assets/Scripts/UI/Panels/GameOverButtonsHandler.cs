using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameOverMenuPanel))]
public class GameOverButtonsHandler : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameCycle _gameCycle;

    private GameOverMenuPanel _gameOverMenu;

    #region MonoBehaviour

    private void Awake()
    {
        _gameOverMenu = GetComponent<GameOverMenuPanel>();
    }

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    #endregion

    private void OnRestartButtonClick()
    {
        _gameCycle.Reload();
    }

    private void OnExitButtonClick()
    {
        _gameCycle.Quit();
    }
}
