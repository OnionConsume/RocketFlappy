using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.5f;
    /// Here I've made a SerializeField, that shows the spawn time inbetween pipes

    [SerializeField] private float _heightRange = 0.45f;
    /// Here I set a range of heigh so the pipes do not spawn outside of the screen

    [SerializeField] private GameObject _pipePrefab;
    /// Here I call the Pipe Prefab, and put it in GameObject so I can call the Pipe prefab with GameObject

    private float _timer;
    /// This keeps track of time so the spawner knows when to spawn again

    void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        if (_timer > _maxTime)
        {
            SpawnPipe();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(
            0f,
            Random.Range(-_heightRange, _heightRange),
            0f
        );

        GameObject pipe = Instantiate(_pipePrefab, spawnPos, Quaternion.identity);

        Destroy(pipe, 10f);
    }
}