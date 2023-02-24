using System.Collections;
using UnityEngine;

public class RandomEnemySpawn : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _point;

    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[_point.childCount];

        for (int i = 0; i < _point.childCount; i++)
        {
            _points[i] = _point.GetChild(i);
        }

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForTwoSeconds = new WaitForSeconds(2f);

        for (int i = 0; i < _points.Length; i++)
        {
            yield return waitForTwoSeconds;

            Instantiate(_enemy, _points[_currentPoint].position, Quaternion.identity);

            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
