using UnityEngine;
using UnityEngine.InputSystem;

// Simpel audio script voor jump en background music
public class SimpleAudio : MonoBehaviour
{
    [SerializeField] private AudioSource jumpSource;     // voor jump geluid
    [SerializeField] private AudioSource musicSource;    // voor achtergrond muziek

    private void Start()
    {
        // start background music
        if (musicSource != null)
        {
            musicSource.loop = true;
            musicSource.Play();
        }
    }
// dit checkt of er op de linker muisknop wordt geklikt
    private void Update()
    {
        // als je linkermuis klikt
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (jumpSource != null)
            {
                jumpSource.Play();
            }
        }
    }
}