using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance {get; private set;}

    [SerializeField]AudioSource sfxAudioSource;

    [SerializeField]private AudioClip deathSound;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        sfxAudioSource = GetComponent<AudioSource>();
    }

    
    public void DeathSound()
    {
        sfxAudioSource.PlayOneShot(deathSound);
    }
}
