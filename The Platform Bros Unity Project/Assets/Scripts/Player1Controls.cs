using UnityEngine;

public class Player1Controls : MonoBehaviour
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

        if (Input.GetKey(KeyCode.RightArrow)) movX = 1f;
        if (Input.GetKey(KeyCode.LeftArrow)) movX = -1f;

        rb.velocity = new Vector2(movX * velocidad, rb.velocity.y);

        //  Salto controlado
        if (Input.GetKeyDown(KeyCode.UpArrow) && puedeSaltar)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
            puedeSaltar = false; // bloquea salto en el aire
        }

        // Crear plataforma
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            manager.IntentarSubirIndice();
            manager.ActivarPlataformaActual(PlatformManager.Jugador.Jugador1);
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
