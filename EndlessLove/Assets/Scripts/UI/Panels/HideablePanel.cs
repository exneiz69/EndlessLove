using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class HideablePanel : MonoBehaviour
{
    [SerializeField] private bool hideOnAwake = true;

    private CanvasGroup _menu;

    #region MonoBehaviour

    protected abstract void OnAwake();

    private void Awake()
    {
        _menu = GetComponent<CanvasGroup>();
        if (hideOnAwake)
        {
            Hide();
        }
        else
        {
            Show();
        }
        OnAwake();
    }

    #endregion

    public void Show()
    {
        _menu.alpha = 1;
        _menu.interactable = true;
    }

    public void Hide()
    {
        _menu.alpha = 0;
        _menu.interactable = false;
    }
}
