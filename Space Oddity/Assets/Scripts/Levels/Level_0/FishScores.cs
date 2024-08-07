using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScores : MonoBehaviour
{
    // scores
    private int basicScore = 2;
    private int betterScore = 5;
    
    // colision -> puntos
    private void OnTriggerEnter2D(Collider2D other)
    {
        // colision con player da puntos al player
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.gameObject.GetComponent<PlayerScore>().score += basicScore;
            GameManager.GM.Fish(this);
            Destroy(gameObject);
        }
        
        // colision con la bala la destruye y le da puntos al player
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            other.gameObject.GetComponent<PlayerScore>().score += betterScore;
            GameManager.GM.Fish(this);
            Destroy(gameObject);
        }
    }

    // destruir a los 4 seg
    private void Update()
    {
        Destroy(gameObject, 4.0f);
    }
}
