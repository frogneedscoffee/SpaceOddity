using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Lilac : MonoBehaviour
{
    SerialPort puertoExtras;

    //public Sprite[] animationSprites;

    //public float animationTime = 5.0f;
    //private SpriteRenderer _spriteRenderer;
    //private int _animationFrame;

    public System.Action killed;

    public Animator animator;

    public int life = 3;

    private void Awake()
    {
        //_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        //InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);

        puertoExtras = FindObjectOfType<PlayerMov>().puerto2;

        puertoExtras.ReadTimeout = 140;
        if (puertoExtras.IsOpen) { }
        else
        {
            puertoExtras.Open();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            life--;

            if (life <= 0)
            {
                animator.Play("LilacDeath");
            }
        }

        //if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        //{
        //    other.gameObject.GetComponent<PlayerDamage>().life = 0;
            
        //    if (puertoExtras.IsOpen)
        //    {
        //        puertoExtras.Write("pierdeVida");
        //    }
        //}
    }

    public void LilacDeath()
    {
        this.killed.Invoke();
        this.gameObject.SetActive(false);
    }


    //private void AnimateSprite()
    //{
    //    _animationFrame++;

    //    if (_animationFrame >= this.animationSprites.Length)
    //    {
    //        _animationFrame = 0;
    //    }

    //    _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    //}
}