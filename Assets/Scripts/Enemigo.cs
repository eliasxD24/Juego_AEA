using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float cooldownAtaque;
    private bool puedeAtacar = true;
    [SerializeField] private float vida;
    [SerializeField] private float velocidadMovimiento = 2f;
    [SerializeField] private float rangoVision = 5f;
    private Animator animator;
    private bool isDead = false;
    private Transform jugador;
    private bool mirandoDerecha = true;
    public AudioClip sonidoMuerte;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (jugador != null && !isDead)
        {
            float distancia = Vector2.Distance(transform.position, jugador.position);
            if (distancia <= rangoVision)
            {
                PerseguirJugador();
                animator.SetTrigger("Caminar");
            }
            else
            {
                animator.SetTrigger("Idle");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!puedeAtacar || isDead) return;

            puedeAtacar = false;

            GameManager.Instance.PerderVida();

            other.gameObject.GetComponent<CharacterController>().AplicarGolpe();

            Invoke("ReactivarAtaque", cooldownAtaque);
        }
    }

    void ReactivarAtaque()
    {
        puedeAtacar = true;
    }

    public void TomarDaño(float daño)
    {
        if (isDead) return;
        vida -= daño;
        animator.SetTrigger("Daño");

        if (vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        isDead = true;
        StartCoroutine(DestruirDespuesDeAnimacion());
        GameManager.Instance.IncrementarPuntaje(10);
        animator.SetTrigger("Muerte");
        AudioManager.Instance.ReproducirSonido(sonidoMuerte, 1.0f);
    }

    private IEnumerator DestruirDespuesDeAnimacion()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(this.gameObject);
    }

    private void PerseguirJugador()
    {
        if (jugador != null)
        {
            Vector2 posicionEnemigo = transform.position;
            Vector2 posicionJugador = jugador.position;
            Vector2 nuevaPosicion = Vector2.MoveTowards(posicionEnemigo, posicionJugador, velocidadMovimiento * Time.deltaTime);
            transform.position = new Vector3(nuevaPosicion.x, nuevaPosicion.y, transform.position.z);
            ActualizarOrientacion(nuevaPosicion.x - posicionEnemigo.x);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            jugador = other.transform;
            animator.SetTrigger("Caminar");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            jugador = null;
            animator.SetTrigger("Idle");
        }
    }

    private void ActualizarOrientacion(float direccion)
    {
        if (direccion > 0 && !mirandoDerecha)
        {
            Voltear();
        }
        else if (direccion < 0 && mirandoDerecha)
        {
            Voltear();
        }
    }

    private void Voltear()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
