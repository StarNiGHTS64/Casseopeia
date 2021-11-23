using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadBuilding2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     void Awake()
     {
         DontDestroyOnLoad(this.gameObject);

     }

    https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneLoaded.html

     
     */



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            SceneManager.LoadScene("Building 2");
        }
    }
}
