using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] buttons;

    public static LevelManager instance;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for(int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(instance);
        } 
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }

    public void RestartScene()
    {
        int curScene = SceneManager.GetActiveScene().buildIndex;
        LoadScene(curScene);
    }
}
