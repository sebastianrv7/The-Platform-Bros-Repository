using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controls : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;

    private Rigidbody2D rb;

    public PlatformManager manager;

    private bool puedeSaltar = false;

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

        //  Salto controlado
        if (Input.GetKeyDown(KeyCode.W) && puedeSaltar)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
            puedeSaltar = false; // bloquea salto en el aire
        }

        // Crear plataforma
        if (Input.GetKeyDown(KeyCode.S))
        {
            manager.IntentarSubirIndice();
            manager.ActivarPlataformaActual(PlatformManager.Jugador.Jugador2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int layer = collision.gameObject.layer;

        //  Piso real  reinicia TODO
        if (layer == LayerMask.NameToLayer("Ground"))
        {
            manager.ReiniciarIndice();
            puedeSaltar = true;
        }

        //  Plataforma  solo reinicia salto
        if (layer == LayerMask.NameToLayer("Platform"))
        {
            puedeSaltar = true;
        }
    }
}
