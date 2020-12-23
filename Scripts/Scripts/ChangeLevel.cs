using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public float delayInSeconds;

    public void change_scene(string scene_name)
    {
        if(scene_name.Equals("Game Over"))
        {
            StartCoroutine(WaitAndLoad(scene_name));
        }
        else if (scene_name.Equals("Game"))
        {
            SceneManager.LoadScene(scene_name);
            //FindObjectOfType<GameSession>().ResetGame();
        }
        else if (scene_name.Equals("Quit"))
        {
            Application.Quit();
            //FindObjectOfType<GameSession>().ResetGame();
        }
        else
        {
            SceneManager.LoadScene(scene_name);
        }
    }

    IEnumerator WaitAndLoad(string scene_name)
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(scene_name);
    }
}
