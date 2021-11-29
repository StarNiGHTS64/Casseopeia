using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToBuilding2 : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject NewEnemy;

    [SerializeField]
    GameObject LastEnemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            PlayerData.position = player.transform.position;
            player.transform.position = new Vector3(118, 13, 0);
            NewEnemy.SetActive(true);
            LastEnemy.SetActive(false);
        }
    }
}
