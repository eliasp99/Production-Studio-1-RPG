using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButton ()
    {
        SceneManager.LoadScene("BattleScene");
    }

    public void OnQuitButton ()
    {
        Application.Quit();
    }

}
