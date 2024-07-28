using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    public Canvas targetCanvas;
    public AudioClip sonidoGanar;
    public AudioSource musicManagerAudioSource;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Asegúrate de que tu personaje tiene el tag "Player"
        {
            targetCanvas.gameObject.SetActive(true);
            AudioManager.Instance.ReproducirSonido(sonidoGanar, 1.0f);
            if (musicManagerAudioSource != null)
            {
                musicManagerAudioSource.Stop();
            }
            if (player != null)
            {
                player.SetActive(false);
            }
            StartCoroutine(CloseGameAfterDelay(5f));
        }
    }

    private IEnumerator CloseGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }
}
