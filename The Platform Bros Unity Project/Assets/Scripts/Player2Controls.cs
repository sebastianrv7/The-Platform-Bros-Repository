using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controls : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;

    private Rigidbody2D rb;

    public PlatformManager manager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movX = 0f;

        if (Input.GetKey(KeyCode.D)) movX = 1f;
        if (Input.GetKey(KeyCode.A)) movX = -1f;

        rb.velocity = new Vector2(movX * velocidad, rb.velocity.y);

        bool enSuelo = Physics2D.Raycast(transform.position, Vector2.down, 1.1f);

        if (Input.GetKeyDown(KeyCode.W) && enSuelo)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            manager.IntentarSubirIndice();          // 1. primero intenta subir
            manager.ActivarPlataformaActual(PlatformManager.Jugador.Jugador2);
        }
    }
}
