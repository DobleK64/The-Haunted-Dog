using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PentagramScore : MonoBehaviour
{
    private float pentagrams;
    //private AudioManager audioManager;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        //audioManager = GetComponent<AudioManager>();
    }

    void Update()
    {
        textMesh.text = pentagrams.ToString("0");
    }

    public void AddPentagrams(float addedP)
    {
        pentagrams += addedP;
        if(pentagrams >= 2)
        {
            SceneManager.LoadScene("Win");
            //audioManager.ClearAudios();
        }
    }
}
