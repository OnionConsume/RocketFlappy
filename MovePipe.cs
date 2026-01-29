using UnityEngine;

// Dit script zorgt ervoor dat de pijpen naar links bewegen
public class MovePipe : MonoBehaviour
{
    // De snelheid waarmee de pijp beweegt
    // SerializeField zodat je dit makkelijk kan tweaken in de Inspector
    [SerializeField] private float _speed = 0.65f;

    private void Update()
    {
        // Vector3.left = links
        // Time.deltaTime zorgt ervoor dat de snelheid overal gelijk is
        // (dus niet sneller op snelle pc’s)
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}