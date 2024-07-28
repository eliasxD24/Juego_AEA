using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoPersonaje : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isRunning;
    private bool isGrounded;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float checkRadius;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isRunning = false;
        isGrounded = false;
    }

    void Update()
    {
        // Verifica si el personaje está en contacto con el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Verifica si el personaje está corriendo y en contacto con el suelo
        if (isGrounded && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            if (!isRunning)
            {
                audioSource.Play();
                isRunning = true;
            }
        }
        else
        {
            if (isRunning)
            {
                audioSource.Stop();
                isRunning = false;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
