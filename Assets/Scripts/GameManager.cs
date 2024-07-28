using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int vidas = 3;
    public HUD hud;
    private int puntaje;
    private int escenaActual;
    public BoxCollider2D Condicion;

    void Start()
    {
        // Inicializar el puntaje según la escena actual
        InicializarPuntajeSegunNivel();

        // Desactivar el BoxCollider2D inicialmente si es necesario
        VerificarCondicion();
    }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Mas de un Game Manager en escena!");
        }

        escenaActual = SceneManager.GetActiveScene().buildIndex;
    }

    void InicializarPuntajeSegunNivel()
    {
        if (hud == null)
        {
            Debug.LogError("El campo 'hud' no está asignado en el GameManager.");
            return;
        }

        switch (escenaActual)
        {
            
            case 3: 
                puntaje = 0;
                break;
            case 4: 
                puntaje = 60;
                break;
            case 5:
                puntaje = 120;
                break;
            case 6:
                puntaje = 180;
                break;
            default:
                puntaje = 0;
                break;
        }

        // Actualizar el HUD con el puntaje inicial
        hud.ActualizarPuntaje(puntaje);
    }

    public void PerderVida()
    {
        vidas -= 1;

        if(vidas == 0)
        {
            CargarEscenaActual();
        }

        hud.DesactivarVida(vidas);
    }

    private void CargarEscenaActual()
    {
        SceneManager.LoadScene(escenaActual);
    }

    public bool RecuperarVida()
    {
        if (vidas == 3)
        {
            return false;
        }
        hud.ActivarVida(vidas);
        vidas += 1;
        return true;
    }

    public void IncrementarPuntaje(int puntos)
    {
        puntaje += puntos;
        hud.ActualizarPuntaje(puntaje);
        VerificarCondicion();
    }

    void VerificarCondicion()
    {
        if (escenaActual == 3 && puntaje >= 60 && Condicion != null)
        {
            Condicion.enabled = false; // Desactivar el BoxCollider2D para la escena Nivel 3
        }
        else if (escenaActual == 4 && puntaje >= 120 && Condicion != null)
        {
            Condicion.enabled = false; // Desactivar el BoxCollider2D para la escena Nivel 4
        }
        else if(escenaActual == 5 && puntaje >= 180 && Condicion != null)
        {
            Condicion.enabled = false;
        }
    }
}
