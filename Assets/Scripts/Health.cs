using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    
    public int _health;
    public int _numHearts;

    public Image[] _hearts;
    public Sprite _fullHeart;
    public Sprite _emptyHeart;

    MenuManager _menuManager;

    void Start()
    {
        _menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
    }
    void Update()
    {
        for (int i = 0; i < _hearts.Length; i++)
        {
            if(_health > _numHearts)
            {
                _health = _numHearts;
            }
            if (_health < _numHearts)
            {
                _numHearts = _health;
            }
    
            
            if(i < _numHearts)
            {
                _hearts[i].enabled = true;
            }
            else
            {
                _hearts[i].enabled = false;
            }
        }

        if(_health == 0)
        {
            _menuManager.Lose();
        }
    }
}
