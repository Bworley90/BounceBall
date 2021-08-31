using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCompletedLevels : MonoBehaviour
{

    public List<GameObject> levels;

    private void Start()
    {
        Debug.Log($"CurrentLevel is {PlayerPrefs.GetInt("currentLevel")}");

        for (int i = 0; i < transform.childCount; i++)
        {
            levels.Add(transform.GetChild(i).gameObject);
        }
    }
    private void Update()
    {
        for (int i = 0; i < levels.Count; i++)
        {

            if (i < PlayerPrefs.GetInt("currentLevel"))
            {
                levels[i].SetActive(true);
            }
            else
            {
                levels[i].SetActive(false);
            }

        }
    }
}
