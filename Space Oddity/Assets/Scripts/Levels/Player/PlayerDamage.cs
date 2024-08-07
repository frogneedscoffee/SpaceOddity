using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO.Ports;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;
    SerialPort puertoExtras;
    public int life = 7;
    public Animator animator;

    //public Sprite[] animationSprites;
    //public float animationTime = 5.0f;
    //private SpriteRenderer _spriteRenderer;
    //private int _animationFrame;
    bool invul = false;
    bool animationOver;
    //string lives;

    private void Start()
    {
        puertoExtras = FindObjectOfType<PlayerMov>().puerto2;

        puertoExtras.ReadTimeout = 140;
        if (!puertoExtras.IsOpen)
        {
            puertoExtras.Open();
        }

        //_spriteRenderer = GetComponent<SpriteRenderer>();
        //InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);

        GameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (life <= 0)
        {
            NoLife();
        }
    }

    private void FixedUpdate()
    {
        Debug.Log("Player Life = " + life);
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("InvaderL2") || other.CompareTag("InvaderL3"))
        {
            Debug.Log("Spaceships collide");
            life = 0;
            NoLife();
        }
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Missile") || other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (!invul)
            {
                StartCoroutine(InvulnerableTime(3,.1f));
            }
        }

    }
    IEnumerator InvulnerableTime(float invTime, float blinkTime)
    {
        invul = true;
        yield return new WaitForSeconds(invTime);
        invul = false;
    }

    public void NoLife()
    {
        animator.Play("PlayerDeath");
        Debug.Log("animation played");
        StartCoroutine(Wait(1f));
        EndGame();
    }

    public void EndGame()
    {
        //puertoExtras.Write("muere");
        if (animationOver == true)
        {
            GameOverPanel.SetActive(true);
            GetComponent<PlayerMov>().canMove = false;
        }
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Debug.Log("wait for " + seconds + " seconds");
        animationOver = true;
    }
}
