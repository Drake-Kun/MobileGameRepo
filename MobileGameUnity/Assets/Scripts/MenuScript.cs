using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public void StartMenuButtonEasy()
    {
        SceneManager.LoadScene("Level1Easy");
    }

    public void StartMenuButtonNormal()
    {
        SceneManager.LoadScene("Level1Normal");
    }

    public void StartMenuButtonHard()
    {
        SceneManager.LoadScene("Level1Hard");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
    }
}
