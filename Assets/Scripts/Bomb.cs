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

    private bool _bombDamaged = false;

    void Start()
    {
        _healthScript = GameObject.Find("Personaje").GetComponent<Health>();
        _sfxAudioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && _bombDamaged == false)
        {
            _sfxAudioSource.PlayOneShot(_bombExploded);
            _healthScript._health -= 1;
            StartCoroutine(PlayExplosionAnimation());
            _bombDamaged = true;
        }
    }

    IEnumerator PlayExplosionAnimation()
    {   
        foreach (Sprite sprite in _explosionSprites)
        {
            _spriteRenderer.sprite = sprite;
            
        
            yield return new WaitForSeconds(_explosionDuration / _explosionSprites.Length);
            //animator.SetBool("is exploded", true);
        }
        
        Destroy(gameObject, _explosionDuration);
    }
}
