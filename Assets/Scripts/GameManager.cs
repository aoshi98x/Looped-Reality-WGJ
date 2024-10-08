using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public GameObject tutorial;
    public bool alreadyLose;
    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    [ContextMenu ("Test GameOver")]
    public void GameOver()
    {
        alreadyLose = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if(alreadyLose)
        {
            GameObject.Find("Screens").SetActive(false);
        }
    }
}
