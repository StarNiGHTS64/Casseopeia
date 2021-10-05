using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinSound;

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.transform.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);

            Destroy(gameObject);
        }
    }
}
