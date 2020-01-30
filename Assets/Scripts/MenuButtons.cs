using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void LoadScene(string scena)
    {
        SceneManager.LoadScene(scena);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
