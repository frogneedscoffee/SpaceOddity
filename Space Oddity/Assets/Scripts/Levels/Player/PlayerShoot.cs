using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class PlayerShoot : MonoBehaviour
{
    SerialPort puertoExtras;

    public AudioClip shootClip;
    public AudioSource audioSource;

    public Bullet bulletprefab;
    private bool playerShoot = false;
    
    public float speed = 3;
     
    private float shootRate = .3f;
    float currshootrate = 0;

    void Start()
    {
        puertoExtras = FindObjectOfType<PlayerMov>().puerto2;

        puertoExtras.ReadTimeout = 4000;
        if (puertoExtras.IsOpen) { }
        else
        {
            puertoExtras.Open();
        }

    }

    private void Update()
    {
        if(currshootrate < shootRate)
        {
            currshootrate += Time.deltaTime;
            return;
        }
        string Lectura = "";
        if (puertoExtras.IsOpen && currshootrate >= shootRate)
        {
            Lectura = puertoExtras.ReadLine();
            if (Lectura.Equals("PRESS"))
            {
                Shoot();
                currshootrate = 0;
                playerShoot = true;
            }
            else
            {
                playerShoot = false;
            }
        }
        else
        {
            Debug.Log("Puerto Cerrado");
        }
    }

    private void Shoot()
    {
        audioSource.PlayOneShot(shootClip);
        Bullet bullet = Instantiate(this.bulletprefab, this.transform.position, Quaternion.identity);
    }

    private void FixedUpdate()
    {
        Debug.Log("Player Shooting " + playerShoot);
    }
}