using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLibrary : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject LibraryEnemy;

    [SerializeField]
    GameObject LastEnemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            PlayerData.position = collision.transform.position;
            player.transform.position = new Vector3(13, 68, 0);
            LibraryEnemy.SetActive(true);
            LastEnemy.SetActive(false);
        }
    }
}
