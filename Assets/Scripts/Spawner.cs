using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private int _spawned;
    private Coroutine _coroutine;
    private bool _canSpawned;

    public int Spawned => _spawned;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null || _currentWaveNumber < 0)
        {
            return;
        }

        if (_spawned == _currentWave.Count)
        {
            if (_currentWave.Count > _currentWaveNumber + 1)
            {
                AllEnemySpawned?.Invoke();
            }

            _canSpawned = false;
            StopCoroutine(_coroutine);
        }
    }

    public void NextWave()
    {
        _spawned = 0;

        SetWave(++_currentWaveNumber);
        EnemyCountChanged?.Invoke(Spawned, _currentWaveNumber);
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        _canSpawned = true;
        _coroutine = StartCoroutine(GenerateEnemies());
    }

    private void Instantiate()
    {
        for (int index = 0; index < _currentWave.Templates.Length; index++)
        {
            Enemy enemy = Instantiate(_currentWave.Templates[index], _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity).GetComponent<Enemy>();
            enemy.Init(_player);
        }

        _spawned++;
        EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
    }

    private IEnumerator GenerateEnemies()
    {
        var pauseSpawn = new WaitForSeconds(_currentWave.Delay);

        while (_canSpawned)
        {
            yield return pauseSpawn;

            Instantiate();
        }
    }
}

[System.Serializable]
public class Wave
{
    public GameObject[] Templates;
    public float Delay;
    public int Count;
}