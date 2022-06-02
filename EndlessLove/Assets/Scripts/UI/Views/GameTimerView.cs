public class GameTimerView : TMPView<int>
{
    #region MonoBehaviour

    protected override void OnAwake() { }

    #endregion

    public override void Render(int elapsedSeconds)
    {
        int seconds = elapsedSeconds % 60;
        int minutes = elapsedSeconds / 60;

        string timerText = "";
        if (minutes < 10)
        {
            timerText += $"0{minutes}";
        }
        else
        {
            timerText += $"{minutes}";
        }
        if (seconds < 10)
        {
            timerText += $":0{seconds}";
        }
        else
        {
            timerText += $":{seconds}";
        }
        Text.text = timerText;
    }
}
