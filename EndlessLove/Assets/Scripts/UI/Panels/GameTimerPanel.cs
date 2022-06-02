using UnityEngine;

public class GameTimerPanel
    : MonoBehaviour
{
    [SerializeField] private GameTimerView _gameTimerView;

    private int _elapsedSeconds = 0;

    #region MonoBehaviour

    private void Start()
    {
        _gameTimerView.Render(_elapsedSeconds);
        Timer.Instance.AddWaitingAction(Tik, 1f);
    }

    #endregion

    private void Tik()
    {
        _elapsedSeconds++;
        _gameTimerView.Render(_elapsedSeconds);
        Timer.Instance.AddWaitingAction(Tik, 1f);
    }
}
