using UnityEngine;

public class PipeIncreaseScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check of speler door de trigger gaat
        if (collision.CompareTag("Player"))
        {
            // score omhoog gooien
            Score.instance.UpdateScore();
        }
    }
}