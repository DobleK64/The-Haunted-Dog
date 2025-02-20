using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioClip audioClip;
    public bool isLoop, playOnGameStart;
    public float volume;
    public string gameObjectName;
    // Start is called before the first frame update
    void Start()
    {
        if (playOnGameStart)
        {
            AudioManager.instance.PlayAudio(audioClip, gameObjectName, isLoop, volume);
        }
    }
}
