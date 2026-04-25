using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGoal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            // Desaparece la estrella
            gameObject.SetActive(false);

            Debug.Log("¡Ganaste!");
        }
    }
}
