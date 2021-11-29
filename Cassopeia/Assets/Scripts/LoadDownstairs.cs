using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadDownstairs : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject LastEnemy;

    [SerializeField]
    GameObject NewEnemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            PlayerData.position.Set(collision.transform.position.x, collision.transform.position.y, 0);
            player.transform.position = new Vector3(6.3f, 2.1f, 0);
            LastEnemy.SetActive(false);
            NewEnemy.SetActive(true);
        }
    }
}
