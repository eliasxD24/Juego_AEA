using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteFollow : MonoBehaviour
{
    public Transform player;  // El transform del jugador para seguir
    private Vector3 offset;   // Desfase inicial entre el límite y el jugador
    private bool stopFollowing = false;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player transform is not assigned!");
            return;
        }

        // Calcula el desfase inicial
        offset = transform.position - player.position;
    }

    void Update()
    {
        if (!stopFollowing && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            // Sigue al jugador con el mismo desfase
            transform.position = player.position + offset;

            // Check if player has reached x position 23
            if (player.position.x >= 23f)
            {
                stopFollowing = true;
            }
        }
    }
}
