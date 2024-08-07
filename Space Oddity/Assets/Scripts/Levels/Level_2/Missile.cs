using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Missile : MonoBehaviour
{    
    SerialPort puertoExtras;

    public Vector3 direction;

    public float speed;

    private void Start()
    {
        puertoExtras = FindObjectOfType<PlayerMov>().puerto2;

        puertoExtras.ReadTimeout = 140;
        if (puertoExtras.IsOpen) { }
        else
        {
            puertoExtras.Open();
        }
    }

    private void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;

        Destroy(this.gameObject, 2.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.gameObject.GetComponent<PlayerDamage>().life -= 1;
            if (puertoExtras.IsOpen)
            {
                //puertoExtras.Write("pierdeVida");
            }

            Destroy(this.gameObject);
            GameManager.GM.Missile(this);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(this.gameObject);
            GameManager.GM.Missile(this);
        }
    }
}