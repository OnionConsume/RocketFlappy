using UnityEngine;

// Dit script is verantwoordelijk voor het spawnen van de pijpen
public class PipeSpawner : MonoBehaviour
{
    // Tijd tussen elke pijp spawn
    // Hoe hoger dit getal, hoe minder vaak er pijpen komen
    [SerializeField] private float _maxTime = 1.5f;

    // Hoe ver omhoog en omlaag de pijpen mogen spawnen
    // Zo blijven ze binnen het scherm
    [SerializeField] private float _heightRange = 0.45f;

    // De pijp prefab die gespawned wordt
    // GameObject zodat we hem kunnen instantiaten
    [SerializeField] private GameObject _pipePrefab;

    // Timer om bij te houden hoe lang het geleden is sinds de laatste spawn
    private float _timer;

    private void Start()
    {
        // Meteen een pijp spawnen zodat het spel niet leeg begint
        SpawnPipe();
    }

    private void Update()
    {
        // Als de timer groter is dan de maximale tijd
        // dan is het tijd om een nieuwe pijp te maken
        if (_timer > _maxTime)
        {
            SpawnPipe();
            _timer = 0; // reset de timer
        }

        // Timer laten oplopen met de tijd tussen frames
        // Time.deltaTime zorgt ervoor dat dit overal hetzelfde loopt
        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        // We beginnen bij de positie van de spawner
        // En voegen een random Y-waarde toe
        // Zo komt elke pijp op een andere hoogte
        Vector3 spawnPos = transform.position + new Vector3(
            0f,
            Random.Range(-_heightRange, _heightRange),
            0f
        );

        // Hier maken we daadwerkelijk een nieuwe pijp aan
        // Quaternion.identity = geen rotatie
        GameObject pipe = Instantiate(_pipePrefab, spawnPos, Quaternion.identity);

        // Na 10 seconden wordt de pijp automatisch verwijderd
        // Dit voorkomt dat de scene vol blijft lopen
        Destroy(pipe, 10f);
    }
}