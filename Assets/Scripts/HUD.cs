using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject[] vidas;
    public TextMeshProUGUI puntajeTexto;

    public TextMeshProUGUI historia1Text;
    public TextMeshProUGUI historia2Text;
    public TextMeshProUGUI historia3Text;
    public float tiempoVisible = 5f;

    void Start()
    {
        // Comenzar la secuencia cuando se inicia el juego
        StartCoroutine(ActivarYDesactivarTextos());
    }

    IEnumerator ActivarYDesactivarTextos()
    {
        // Activar Historia1
        historia1Text.gameObject.SetActive(true);
        yield return new WaitForSeconds(tiempoVisible);

        // Desactivar Historia1 y activar Historia2
        historia1Text.gameObject.SetActive(false);
        historia2Text.gameObject.SetActive(true);
        historia3Text.gameObject.SetActive(false);
        yield return new WaitForSeconds(tiempoVisible);

        // Desactivar Historia2 después de tiempoVisible segundos
        historia2Text.gameObject.SetActive(false);
        historia3Text.gameObject.SetActive(true);
        yield return new WaitForSeconds(tiempoVisible);

        historia3Text.gameObject.SetActive(false);
    }

    public void DesactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
    }

    public void ActivarVida(int indice)
    {
        vidas[indice].SetActive(true);
    }

    public void ActualizarPuntaje(int puntaje)
    {
        puntajeTexto.text = ": " + puntaje;
    }
}
