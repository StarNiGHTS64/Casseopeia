using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoseState : MonoBehaviour
{
   public void LoadGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
