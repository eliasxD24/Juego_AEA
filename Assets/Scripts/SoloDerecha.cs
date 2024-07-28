using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloDerecha : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento hacia la derecha

    private Rigidbody2D rigidbody2D;
    private Animator animator;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("No se encontró un componente Animator en el GameObject.");
        }
    }

    private void Update()
    {
        MoverDerecha();
    }

    private void MoverDerecha()
    {
        rigidbody2D.velocity = new Vector2(velocidad, rigidbody2D.velocity.y);

        // Activar la animación de correr
        if (animator != null)
        {
            animator.SetBool("isRunning", true);
        }
    }
}
