using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class AsteroidDamage : MonoBehaviour
{
    SerialPort puertoExtras;
    [SerializeField] float deathTime = 3;

    private void Start()
    {
        Destroy(this.gameObject, deathTime);

        puertoExtras = FindObjectOfType<PlayerMov>().puerto2;

        puertoExtras.ReadTimeout = 40;
        
        if (puertoExtras.IsOpen) { }
        
        else 
        {
            puertoExtras.Open();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.gameObject.GetComponent<PlayerDamage>().life -= 1;
            Destroy(gameObject);
            GameManager.GM.AsteroidDestroyed(this);

            if (puertoExtras.IsOpen)
            {
                //puertoExtras.Write("pierdeVida");
                Debug.Log("Puerto Abierto");
            }
        }
    }

    public void OnDestroy()
    {
        Debug.Log("death :(");
    }
}