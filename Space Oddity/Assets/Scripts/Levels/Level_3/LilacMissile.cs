using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class LilacMissile : MonoBehaviour
{
    SerialPort puertoextras;

    [SerializeField] private GameObject target;
    [SerializeField] private float speed;
    Rigidbody2D RB;
    Vector2 moveDirection;

    private void Start()
    {
        puertoextras = FindObjectOfType<PlayerMov>().puerto2;

        puertoextras.ReadTimeout = 400;
        if (!puertoextras.IsOpen) 
        {
            puertoextras.Open();
        }
        Destroy(gameObject, 1.2f);
    }

    private void Update()
    {
        target = FindObjectOfType<PlayerMov>().gameObject;

        Debug.Log("soy el misil, apunto a " + target.transform.position);

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.gameObject.GetComponent<PlayerDamage>().life -= 1;
            Destroy(gameObject);
            GameManager.GM.LilacMissile(this);
            Debug.Log("Hit!");

            if (puertoextras.IsOpen)
            {
                //puertoextras.Write("pierdeVida");
            }
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(gameObject);
            GameManager.GM.LilacMissile(this);
        }
    }

    private void OnDestroy()
    {
        GameManager.GM.LilacMissile(this);
    }
}
