using System;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : Component, IFinishable<T>
{
    [SerializeField] private T _prefab;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private GameObject _poolContainer;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private string _spawnPointsContainerTag;

    protected Transform[] SpawnPoints => _spawnPoints;
    protected ObjectPool<T> ObjectPool => _objectPool;

    private Transform[] _spawnPoints;
    private ObjectPool<T> _objectPool;

    #region MonoBehaviour

    protected abstract void OnAwake();

    protected abstract void OnStart();

    protected virtual void OnValidate()
    {
        _secondsBetweenSpawn = _secondsBetweenSpawn < 0 ? 0 : _secondsBetweenSpawn;
        _poolCapacity = _poolCapacity < 0 ? 0 : _poolCapacity;
    }

    private void Awake()
    {
        int childCount = transform.childCount;
        Transform spawnPointsContainer = null;
        for (int i = 0; i < childCount; i++)
        {
            if (transform.GetChild(i).CompareTag(_spawnPointsContainerTag))
            {
                spawnPointsContainer = transform.GetChild(i);
                break;
            }
        }
        if (spawnPointsContainer == null || spawnPointsContainer.childCount == 0)
        {
            throw new InvalidOperationException();
        }
        else
        {
            _spawnPoints = new Transform[spawnPointsContainer.childCount];
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                _spawnPoints[i] = spawnPointsContainer.GetChild(i);
            }
            _objectPool = new ObjectPool<T>(_poolContainer, _poolCapacity, _prefab);
            OnAwake();
        }
    }

    private void Start()
    {
        Timer.Instance.AddWaitingAction(Spawn, _secondsBetweenSpawn);
        OnStart();
    }

    #endregion

    protected abstract bool CheckSpawnAvailability();

    protected abstract void Prepare(T spawnObject);

    private void Spawn()
    {
        if (CheckSpawnAvailability())
        {
            if (_objectPool.TryGetObject(out T spawnObject))
            {
                Prepare(spawnObject);
            }
        }
        Timer.Instance.AddWaitingAction(Spawn, _secondsBetweenSpawn);
    }
}
