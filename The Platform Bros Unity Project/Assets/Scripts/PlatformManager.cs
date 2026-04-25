using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject[] plataformas;

    private int indice = 0;

    private GameObject plataformaJugador1;
    private GameObject plataformaJugador2;

    public enum Jugador
    {
        Jugador1,
        Jugador2
    }

    public void IntentarSubirIndice()
    {
        if (indice >= plataformas.Length) return;

        Plataforma plataformaActual = plataformas[indice].GetComponent<Plataforma>();

        if (plataformaActual != null && plataformaActual.AmbosEncima())
        {
            indice++;
            Debug.Log("Indice subió a: " + indice);
        }
    }

    public void ActivarPlataformaActual(Jugador jugador)
    {
        if (indice >= plataformas.Length) return;

        GameObject nuevaPlataforma = plataformas[indice];

        if (jugador == Jugador.Jugador1)
        {
            //  Si el otro jugador tenía esta misma plataforma  limpiarlo
            if (plataformaJugador2 == nuevaPlataforma)
            {
                plataformaJugador2 = null;
            }

            // Apagar la anterior de jugador 1
            if (plataformaJugador1 != null)
                plataformaJugador1.SetActive(false);

            plataformaJugador1 = nuevaPlataforma;
        }
        else
        {
            //  Si el otro jugador tenía esta misma plataforma  limpiarlo
            if (plataformaJugador1 == nuevaPlataforma)
            {
                plataformaJugador1 = null;
            }

            // Apagar la anterior de jugador 2
            if (plataformaJugador2 != null)
                plataformaJugador2.SetActive(false);

            plataformaJugador2 = nuevaPlataforma;
        }

        // Activar nueva
        nuevaPlataforma.SetActive(true);

        // Color
        SpriteRenderer sr = nuevaPlataforma.GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            Color color;

            if (jugador == Jugador.Jugador1)
                ColorUtility.TryParseHtmlString("#66A2FF", out color);
            else
                ColorUtility.TryParseHtmlString("#F59B60", out color);

            sr.color = color;
        }

        Debug.Log("Jugador " + jugador + " activó plataforma " + indice);
    }

    public void ReiniciarIndice()
    {
        indice = 0;      
        Debug.Log("Indice reiniciado a 0");
    }
}
