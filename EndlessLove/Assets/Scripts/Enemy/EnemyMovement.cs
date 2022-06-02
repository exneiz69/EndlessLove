using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    public float MoveSpeed
    {
        get => _moveSpeed;
        set => _moveSpeed = value < 0 ? 0 : value;
    }

    #region MonoBehaviour

    private void OnValidate()
    {
        _moveSpeed = _moveSpeed < 0 ? 0 : _moveSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
    }

    #endregion
}
