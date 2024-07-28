using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoSeguir : MonoBehaviour
{
    public Transform player;
    public float parallaxEffectMultiplier = 0.5f;
    public float backgroundSpeed = 0.1f;
    private Vector3 lastPlayerPosition;
    private bool stopEffect = false;
    private MovimientoPersonaje playerMovementScript;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player transform is not assigned!");
            return;
        }
        lastPlayerPosition = player.position;
        playerMovementScript = player.GetComponent<MovimientoPersonaje>();
        if (playerMovementScript == null)
        {
            Debug.LogError("PlayerMovement script is not assigned to the player!");
            return;
        }
    }

    void Update()
    {
        if (stopEffect)
            return;

        // Movimiento automático del fondo
        Vector3 deltaMovement = player.position - lastPlayerPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier, 0, 0);

        // Mueve el fondo ligeramente a la izquierda
        transform.position += new Vector3(-backgroundSpeed * Time.deltaTime, 0, 0);

        lastPlayerPosition = player.position;

        // Verifica si el jugador ha alcanzado la posición x 23
        if (player.position.x >= 23f)
        {
            stopEffect = true;
            playerMovementScript.ChangeSpeed(7f);  // Cambia la velocidad del jugador a 7
        }
    }
}
