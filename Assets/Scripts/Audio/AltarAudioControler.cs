using System.Collections.Generic;
using UnityEngine;

public class AltarAudioControler : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> whispers;
    float time = 0;
    int index;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Este update trabaja de forma cada 10 segundos ejecuta un audio de susurros aleatorio de los presentes 
    /// en la lista whispers
    /// </summary>
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 10) 
        {
            time = 0;
            index = Random.Range(0, whispers.Count - 1);
            audioSource.PlayOneShot(whispers[index]);
        }
    }
}
