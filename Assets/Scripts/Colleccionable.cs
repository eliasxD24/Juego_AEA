using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Colleccionable : MonoBehaviour
{
    public static event Action OnSwordCollected;
    public RuntimeAnimatorController newAnimatorController;
    public GameObject swordIcon;
    public AudioClip sonidoEspada;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Cambiar el AnimatorController del personaje
            Animator playerAnimator = collision.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.runtimeAnimatorController = newAnimatorController;
            }

            if (swordIcon != null)
            {
                swordIcon.SetActive(true);
            }

            // Disparar el evento de recolección de la espada
            OnSwordCollected?.Invoke();

            melee.espadaRecogida = true;

            if (sonidoEspada != null)
            {
                AudioSource audioSource = collision.gameObject.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource = collision.gameObject.AddComponent<AudioSource>();
                }
                float volume = 1.0f; // por ejemplo, volumen al 50%
                audioSource.PlayOneShot(sonidoEspada, volume);
            }

            gameObject.SetActive(false);
        }
    }
}
