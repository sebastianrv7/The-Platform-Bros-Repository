using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject[] plataformas;

    public void ActivarPrimeraPlataforma()
    {
        if (plataformas.Length > 0)
        {
            plataformas[0].SetActive(true);
            Debug.Log("Plataforma 0 activada");
        }
    }
}
