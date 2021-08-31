using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public void ToggleUIOn(GameObject objectToToggle)
    {
        //GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayer>().enabled = false;
        objectToToggle.SetActive(true);
    }

    public void ToggleUIOff(GameObject objectToToggle)
    {
        objectToToggle.SetActive(false);
        //GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayer>().enabled = true;

    }

    public void NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
        if (PlayerPrefs.GetInt("currentLevel") <= currentScene)
        {
            PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("currentLevel") + 1);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (PlayerPrefs.GetInt("currentLevel") < currentScene)
        {
            PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("currentLevel") + 1);
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuPlay()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentLevel"));
    }

    public void TempResetLevels()
    {
        PlayerPrefs.SetInt("currentLevel", 1);
        GetComponent<Animator>().SetTrigger("NewGameButtonCancel");
    }

    public void NewGameSelected()
    {
        GetComponent<Animator>().SetTrigger("NewGameButton");
    }

    public void NewGameButtonCancel()
    {
        GetComponent<Animator>().SetTrigger("NewGameButtonCancel");
    }
}
