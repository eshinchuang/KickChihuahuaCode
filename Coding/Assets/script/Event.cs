using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
    public void OnButtonClick()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void NextStage()
    {
        SceneManager.LoadScene("Game 1", LoadSceneMode.Single);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
