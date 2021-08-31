using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIButtons : MonoBehaviour
{
    public void ClickedButton(string TriggerText)
    {
        GetComponent<Animator>().SetTrigger(TriggerText);
    }

    public void LevelSelected(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

   
}
