using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private List<GameObject> audioList;


    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);    //se destruye el  gameObject para que no  haya dos o mas gm en el juego
        }
    }

    private void Start()
    {
        audioList = new List<GameObject>();
    }

    public AudioSource PlayAudio(AudioClip audioClip, string gameObjectName, bool isLoop = false, float volume = 1.0f)           //valor por defecto, tiene que estar en la ultima parte y no pueden estar intercalados 
    {
        GameObject audioObject = new GameObject(gameObjectName);
        audioObject.transform.SetParent(transform);           //hace que los objetos son hijos del game manager
        AudioSource audioSourceComponent = audioObject.AddComponent<AudioSource>();            //aniado componente AudioSource 
        audioSourceComponent.clip = audioClip;                                                 //le asignamos clip, volumen y loop al componente
        audioSourceComponent.volume = volume;
        audioSourceComponent.loop = isLoop;
        audioSourceComponent.Play();                                                           //darle a empezar
        audioList.Add(audioObject);
        if (!isLoop)           //si audio no esta en loop
        {
            StartCoroutine(WaitAudioEnd(audioSourceComponent));      // Una corrutina -  permite ejecutarse en cada frame o que espere cierto numero de segundos antes de continuar,.no pausa la ejecucion del programa entre los bucles.
        }
        return audioSourceComponent;
    }

    IEnumerator WaitAudioEnd(AudioSource src)  // Una corrutina -  no pausa la ejecucion del programa entre los bucles. Hilos y p
    {
        while (src && src.isPlaying)      //esperar que el src acabe 
        {
            yield return null;     // le devuelve el control a unity pero despues vuelve a yield 
        }
        Destroy(src.gameObject);
    }

    public void ClearAudios()
    {
        foreach (GameObject audioObject in audioList)
        {
            Destroy(audioObject);
        }
        audioList.Clear();
    }
    public AudioSource PlayAudio3D(AudioClip audioClip, string gameObjectName, bool isLoop = false, float volume = 1.0f)
    {
        AudioSource audioSource = PlayAudio(audioClip, gameObjectName, false, volume);
        audioSource.spatialBlend = 1;
        return audioSource;
    }
}
