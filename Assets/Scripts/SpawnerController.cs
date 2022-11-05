using System.Collections;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    private bool _isStarted;
    private int _time;

    private void OnEnable() => ApplyValues.spawnTimeApplied += UpdateSpawnTime;

    private void OnDisable() => ApplyValues.spawnTimeApplied -= UpdateSpawnTime;

    private IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(_cube, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_time);
        }
    }

    private void UpdateSpawnTime(int time)
    {
        _time = time;
        if (time > 0 && !_isStarted)
        {
            StartCoroutine(Spawn());
            _isStarted = true;
        }
    }
}
