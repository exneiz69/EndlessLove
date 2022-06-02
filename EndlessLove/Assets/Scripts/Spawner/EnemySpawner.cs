using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private float _minEmenySpeed;
    [SerializeField] private float _maxEmenySpeed;
    [SerializeField] private Transform _endOfVisibleArea;

    private int _lastCheckedSpawnPointIndex;
    private int _lastCheckedSpriteIndex;
    private float _lastCheckedMoveSpeed;
    private Enemy[] _lastSpawnedEnemies;

    #region MonoBehaviour

    protected override void OnValidate()
    {
        base.OnValidate();
        _minEmenySpeed = _minEmenySpeed < 0 ? 0 : _minEmenySpeed;
        _maxEmenySpeed = _maxEmenySpeed < 0 ? 0 : _maxEmenySpeed;
        if (_minEmenySpeed > _maxEmenySpeed)
        {
            _minEmenySpeed = _maxEmenySpeed;
        }
    }

    protected override void OnAwake()
    {
        _lastSpawnedEnemies = new Enemy[SpawnPoints.Length];
    }

    protected override void OnStart() { }

    #endregion

    protected override bool CheckSpawnAvailability()
    {
        _lastCheckedSpawnPointIndex = Random.Range(0, SpawnPoints.Length);
        _lastCheckedSpriteIndex = Random.Range(0, _sprites.Length);
        _lastCheckedMoveSpeed = Random.Range(_minEmenySpeed, _maxEmenySpeed);
        return CheckSpawnAvailability(_lastCheckedSpawnPointIndex, _lastCheckedSpriteIndex, _lastCheckedMoveSpeed);
    }

    protected override void Prepare(Enemy enemy)
    {
        enemy.transform.position = SpawnPoints[_lastCheckedSpawnPointIndex].position;
        enemy.GetComponent<SpriteRenderer>().sprite = _sprites[_lastCheckedSpriteIndex];
        enemy.GetComponent<EnemyMovement>().MoveSpeed = _lastCheckedMoveSpeed;
        enemy.gameObject.SetActive(true);
        _lastSpawnedEnemies[_lastCheckedSpawnPointIndex] = enemy;
    }

    private bool CheckSpawnAvailability(int spawnPointIndex, int spriteIntex, float moveSpeed)
    {
        Enemy lastSpawnedEnemy = _lastSpawnedEnemies[spawnPointIndex];
        bool isSpawnAvailable = false;

        if (lastSpawnedEnemy is null || !lastSpawnedEnemy.gameObject.activeSelf)
        {
            isSpawnAvailable = true;
        }
        else
        {
            float point1 = SpawnPoints[spawnPointIndex].position.x - _sprites[spriteIntex].bounds.size.y / 2f;
            float point2 = lastSpawnedEnemy.transform.position.x + lastSpawnedEnemy.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2f;
            if (point1 > point2)
            {
                float speed1 = moveSpeed;
                float speed2 = lastSpawnedEnemy.GetComponent<EnemyMovement>().MoveSpeed;
                if (CheckPointsCollision(point1, speed1, point2, speed2, out float collisionPoint))
                {
                    Transform startOfVisibleArea = SpawnPoints[spawnPointIndex];
                    if (collisionPoint < _endOfVisibleArea.position.x || collisionPoint > (startOfVisibleArea.position.x + 3))
                    {
                        isSpawnAvailable = true;
                    }
                }
                else
                {
                    isSpawnAvailable = true;
                }
            }
        }

        return isSpawnAvailable;
    }

    private bool CheckPointsCollision(float point1, float speed1, float point2, float speed2, out float collisionPoint)
    {
        bool isSuccess;

        if (point1 == point2)
        {
            collisionPoint = point1;
            isSuccess = true;
        }
        else if (speed1 == speed2)
        {
            collisionPoint = float.NaN;
            isSuccess = false;
        }
        else
        {
            collisionPoint = (speed2 * point1 - speed1 * point2) / (speed2 - speed1);
            isSuccess = true;
        }

        return isSuccess;
    }
}