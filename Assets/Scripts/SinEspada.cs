using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SinEspada : MonoBehaviour
{
    public GameObject textMeshObject; // Asigna el GameObject del TextMesh en el Inspector
    private bool hasSword = false;
    public Transform playerTransform;
    private void OnEnable()
    {
        // Suscribirse al evento de recolecci�n de la espada
        Colleccionable.OnSwordCollected += HandleSwordCollected;
    }

    private void OnDisable()
    {
        // Desuscribirse del evento de recolecci�n de la espada
        Colleccionable.OnSwordCollected -= HandleSwordCollected;
    }

    private void HandleSwordCollected()
    {
        // Desactivar el BoxCollider2D cuando se recoge la espada
        gameObject.SetActive(false);
        hasSword = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasSword && collision.collider.CompareTag("Player"))
        {
            StartCoroutine(ShowMessage());
        }
    }

    private IEnumerator ShowMessage()
    {
        textMeshObject.SetActive(true);

        // Hacer que el texto siga al jugador mientras est� visible
        float duration = 2f; // Duraci�n del mensaje en segundos
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // Actualizar la posici�n del TextMesh para que est� sobre el jugador
            Vector3 offset = new Vector3(0, 2, 0); // Ajusta este valor seg�n sea necesario
            textMeshObject.transform.position = playerTransform.position + offset;

            yield return null;
        }

        textMeshObject.SetActive(false);
    }
}
