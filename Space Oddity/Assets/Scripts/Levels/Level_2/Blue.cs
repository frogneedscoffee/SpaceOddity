using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Blue : MonoBehaviour
{
    SerialPort puertoExtras;

    public Animator animator;

    //public Sprite[] animationSprites;

    //public float animationTime = 5.0f;
    //private SpriteRenderer _spriteRenderer;
    //private int _animationFrame;

    public System.Action killed;

    public int life = 1;

    private void Awake()
    {
        //_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        puertoExtras = FindObjectOfType<PlayerMov>().puerto2;

        //InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);

        puertoExtras.ReadTimeout = 40;
        if (puertoExtras.IsOpen) { }
        else
        {
            puertoExtras.Open();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        //{
        //    other.gameObject.GetComponent<PlayerDamage>().life = 0;

        //    if (puertoExtras.IsOpen)
        //    {
        //        puertoExtras.Write("pierdeVida");
        //    }
        //}

        if(other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            life--;

            if (life <= 0)
            {
                animator.Play("BlueDeath");
                //animator.Play("BlueDeath");
            }
        }
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

    public void BlueDeath()
    {
        this.killed.Invoke();
        this.gameObject.SetActive(false);
    }
    public void Debbug()
    {
        print("Se reproduce la anim");
    }
}