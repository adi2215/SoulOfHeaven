using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public void Lose()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void ExitToGame() => Application.Quit();
}
