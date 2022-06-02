    using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyMovement))]
public class Enemy : MonoBehaviour, IFinishable<Enemy>
{
    [SerializeField] private int _damage;

    public event UnityAction<Enemy> Finished;

    public int Damage
    {
        get => _damage;
        set => _damage = value > 0 ? value : 0;
    }

    #region MonoBehaviour

    private void OnValidate()
    {
        _damage = _damage < 0 ? 0 : _damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(_damage);
        }
        Die();
    }

    #endregion

    public void Restart() { }

    private void Die()
    {
        gameObject.SetActive(false);
        Finished?.Invoke(this);
    }
}
