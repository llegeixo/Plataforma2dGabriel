using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Health _healthScript;

    AudioSource _sfxAudioSource;
    public Sprite[] _explosionSprites;
    [SerializeField]private AudioClip _bombExploded;
    public float _explosionDuration = 1.0f;

    [SerializeField] private Animator animator;

    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _healthScript = GameObject.Find("Personaje").GetComponent<Health>();
        _sfxAudioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bomb"))
        {
            _sfxAudioSource.PlayOneShot(_bombExploded);
            _healthScript._health = -1;
            StartCoroutine(PlayExplosionAnimation());
            Destroy(gameObject, _explosionDuration);
        }
    }

    IEnumerator PlayExplosionAnimation()
    {
        
        GetComponent<Collider>().enabled = false;

        foreach (Sprite sprite in _explosionSprites)
        {
            _spriteRenderer.sprite = sprite;
            yield return new WaitForSeconds(_explosionDuration / _explosionSprites.Length);
        }
        
        GetComponent<Collider>().enabled = true;
    }
}
