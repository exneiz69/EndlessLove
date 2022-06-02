using UnityEngine;

public class HealthBarPanel: MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private HealthBarView _healthBarView;
    [SerializeField] private HealthTextView _healthTextView;

    private int _maxHealth;

    #region MonoBehaviour

    private void Awake()
    {
        _maxHealth = _player.MaxHealth;
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    #endregion

    private void OnHealthChanged(int health)
    {
        _healthBarView.Render(health, _maxHealth);
        _healthTextView.Render(health);
    }
}
