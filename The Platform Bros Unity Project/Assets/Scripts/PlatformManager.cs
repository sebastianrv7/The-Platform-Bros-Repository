using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject[] plataformas;

    private int indice = 0;
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

        GameObject plataforma = plataformas[indice];

        // Evita reactivar la misma plataforma varias veces
        if (!plataforma.activeSelf)
        {
            plataforma.SetActive(true);

            SpriteRenderer sr = plataforma.GetComponent<SpriteRenderer>();

            if (sr != null)
            {
                Color color;

                if (jugador == Jugador.Jugador1)
                    ColorUtility.TryParseHtmlString("#66A2FF", out color);
                else
                    ColorUtility.TryParseHtmlString("#F59B60", out color);

                sr.color = color;
            }

            Debug.Log("Plataforma " + indice + " activada por " + jugador);
        }
    }
}
