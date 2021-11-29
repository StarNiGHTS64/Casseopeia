using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (PlayerData.keyCount == 6)
            {
                SceneManager.LoadScene("WinScreen");
            }
            else
            {
                // you havent collected all keys message
            }
        }
    }
}
