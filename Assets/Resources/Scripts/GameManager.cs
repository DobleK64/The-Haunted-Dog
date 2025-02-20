using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public Image vidaVisual;
    public enum GameManagerVariables { Pentagrams }
    private float initialLife;
    
    private float life = 1f;
    
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
        initialLife = life;
    }

    void Update()
    {
        vidaVisual.fillAmount = life/1;
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
    public float GetLifes()
    {
        return life;
    }
    public void AddLifes(float lifeA)
    {
        life += lifeA;

        if (life <= 0)
        {
            SceneManager.LoadScene("Game");
            life = initialLife;
        }
    }
    
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
