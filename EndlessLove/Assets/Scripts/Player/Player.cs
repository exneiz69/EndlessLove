using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _health;
    private bool _alive = true;

    public event UnityEngine.Events.UnityAction<int> HealthChanged;
    public event UnityEngine.Events.UnityAction Died;

    public int MaxHealth => _maxHealth;

    public int Health => _health;

    #region MonoBehaviour

    private void OnValidate()
    {
        _maxHealth = _maxHealth < 0 ? 0 : _maxHealth;
    }

    private void Awake()
    {
        _health = _maxHealth;
    }

    private void Start()
    {
        HealthChanged(_health);
    }

    #endregion

    public void TakeDamage(int damage)
    {
        if (_alive)
        {
            if (_health - damage > 0)
            {
                _health -= damage;
                HealthChanged(_health);
            }
            else
            {
                _health = 0;
                HealthChanged(_health);
                Die();
            }
        }
    }

    private void Die()
    {
        _alive = false;
        Died();
    }
}
