using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadBuilding2 : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject LastEnemy;

    [SerializeField]
    GameObject NextEnemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerData.position = player.transform.position;
            player.transform.position = new Vector3(82, 13, 0);
            LastEnemy.SetActive(false);
            NextEnemy.SetActive(true);
        }
    }
}
