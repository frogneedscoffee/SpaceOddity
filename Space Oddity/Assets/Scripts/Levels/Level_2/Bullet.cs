using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    private void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;

        Destroy(this.gameObject, 3.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("InvaderL2"))
        {
            Destroy(this.gameObject);
            GameManager.GM.BulletColl(this);
        }

        else if (other.gameObject.layer == LayerMask.NameToLayer("Boundary"))
        {
            Destroy(gameObject);
        }

        else if (other.gameObject.CompareTag("InvaderL3"))
        {
            Destroy(gameObject);
            GameManager.GM.BulletColl(this);
        }

        else if (other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            Destroy(gameObject);
            GameManager.GM.BulletColl(this);
        }
    }
}