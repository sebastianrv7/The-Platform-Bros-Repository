using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    private bool jugador1Encima = false;
    private bool jugador2Encima = false;

    public bool AmbosEncima()
    {
        return jugador1Encima && jugador2Encima;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
            jugador1Encima = true;

        if (collision.gameObject.CompareTag("Player2"))
            jugador2Encima = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
            jugador1Encima = false;

        if (collision.gameObject.CompareTag("Player2"))
            jugador2Encima = false;
    }
}
