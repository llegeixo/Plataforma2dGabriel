using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int stars = 0;
    [SerializeField] private Text starsText;
    AudioSource sfxAudioSource;
    [SerializeField]private AudioClip starPicked;

    MenuManager _menuManager;

    void Start()
    {
        sfxAudioSource = GetComponent<AudioSource>();
        _menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
            stars++;
            starsText.text = "x " + stars;
            sfxAudioSource.PlayOneShot(starPicked);
        }
    }

    public void Update()
    {
        if(stars == 6)
        {
            _menuManager.Win();
        }
    }
    
}
