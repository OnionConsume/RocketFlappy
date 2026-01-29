using System;
using UnityEngine;
using UnityEngine.InputSystem; // nodig zodat we muisklikken kunnen lezen

// Dit script regelt het vliegen, net zoals Flappy Bird
public class FlyBehaviour : MonoBehaviour
{
    // Hoe hard de raket omhoog gaat als je klikt
    // Dit is een variable zodat je het makkelijk in de Inspector kan aanpassen
    [SerializeField] private float _velocity = 1.5f;

    // Hoe sterk de raket draait wanneer hij omhoog of omlaag gaat
    // Ziet er natuurlijker uit dan een stijve sprite
    [SerializeField] private float _rotationspeed = 15f;

    // Rigidbody2D gebruiken we omdat Unity dan zwaartekracht en physics regelt
    private Rigidbody2D _rb;

    private void Start()
    {
        // We pakken hier de Rigidbody2D van dit object
        // Dat doen we 1 keer in Start zodat we het niet elke frame hoeven te zoeken
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Update is het beste voor input
        // We checken hier of de linkermuisknop net is ingedrukt
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // We zetten de verticale snelheid omhoog
            // We gebruiken velocity i.p.v. force zodat het direct reageert
            _rb.linearVelocity = Vector2.up * _velocity;
        }
    }

    private void FixedUpdate()
    {
        // FixedUpdate is beter voor physics dingen zoals beweging en rotatie
        // Hier laten we de raket kantelen op basis van hoe snel hij omhoog of omlaag gaat
        // Positieve Y = omhoog kijken, negatieve Y = omlaag kijken
        transform.rotation = Quaternion.Euler(
            0,
            0,
            _rb.linearVelocity.y * _rotationspeed
        );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Zodra we ergens tegenaan knallen is het game over
        // De GameManager regelt wat er dan precies gebeurt
        GameManager.instance.GameOver();
    }
}