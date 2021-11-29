using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    public void LoadWinGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
