using UnityEngine;

public class HealthTextView : TMPView<int>
{
    #region MonoBehaviour

    protected override void OnAwake() { }

    #endregion

    public override void Render(int health)
    {
        Text.text = health.ToString();
    }
}
