using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLastLevel : MonoBehaviour
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
            PlayerData.position = player.transform.position;
            player.transform.position = new Vector3(170, 5, 0);
            LastEnemy.SetActive(false);
            NewEnemy.SetActive(true);
        }
    }
}
