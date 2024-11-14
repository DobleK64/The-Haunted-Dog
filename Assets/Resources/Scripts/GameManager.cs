using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum GameManagerVariables { Pentagrams }

    private int Pentagrams = 0;

    private void Awake()
    {
        //Singleton
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Getter
    public int GetPentagrams()
    {
        return Pentagrams;
    }

    //Setter
    public void SetPentagrams(int value)
    {
        Pentagrams = value;
    }

    //Callback
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        AudioManager.instance.ClearAudios();
    }

    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
