using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;

    private Vector3 _targetPosition;

    #region MonoBehaviour

    private void OnValidate()
    {
        _moveSpeed = _moveSpeed < 0 ? 0 : _moveSpeed;
        _stepSize = _stepSize < 0 ? 0 : _stepSize;
        if (_minHeight > _maxHeight)
        {
            _minHeight = _maxHeight;
        }
    }

    private void Awake()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }
    }

    #endregion

    public bool TryDodgeUp()
    {
        if (_targetPosition.y + _stepSize <= _maxHeight)
        {
            ChangeTargetPosition(_stepSize);
            return true;
        }
        else
        {
            return false;
        }        
    }

    public bool TryDodgeDown()
    {
        if (_targetPosition.y - _stepSize >= _minHeight)
        {
            ChangeTargetPosition(-_stepSize);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ChangeTargetPosition(float stepSize) =>
        _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y + stepSize, _targetPosition.z);
}
