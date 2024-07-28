using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {  get; private set; }
    private AudioSource audioSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Mas de un AudioManager");
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void ReproducirSonido(AudioClip audio, float volumen = 1.0f)
    {
        audioSource.PlayOneShot(audio);
    }

    public void PlaySwordSwingSound(AudioClip clip, float volume = 1.0f)
    {
        audioSource.PlayOneShot(clip, volume);
    }
}
