using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMov : MonoBehaviour
{
    public float speed = 3;

    public Sprite[] animationSprites;
    public float animationTime = 5.0f;
    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
        //Invoke(nameof(AnimateSprite), this.animationTime);
    }

    private void AnimateSprite()
    {
        _animationFrame++;

        if (_animationFrame >= this.animationSprites.Length)
        {
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }

    void Update()
    {
        transform.position += -transform.up * Time.deltaTime * speed;
    }
}