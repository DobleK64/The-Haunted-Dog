using UnityEngine;

public class RadioController : MonoBehaviour
{
    public float detectionRadius = 5f; // Radio de detección
    public AudioClip beepSound; // Sonido del pitido
    private AudioSource audioSource;
    private bool isBeeping = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = beepSound;
        audioSource.loop = true; // Reproducir en bucle
    }

    void Update()
    {
        DetectPentagrams();
    }

    void DetectPentagrams()
    {
        // Busca todos los objetos con la etiqueta "Pentagrama"
        GameObject[] pentagrams = GameObject.FindGameObjectsWithTag("Pentagram");
        foreach (GameObject pentagram in pentagrams)
        {
            float distance = Vector3.Distance(transform.position, pentagram.transform.position);
            if (distance < detectionRadius)
            {
                if (!isBeeping)
                {
                    StartBeeping();
                }
                return; // Si se encuentra un pentagrama, no hay necesidad de seguir buscando
            }
        }

        // Si no hay pentagramas cerca, deja de pitar
        if (isBeeping)
        {
            StopBeeping();
        }
    }

    void StartBeeping()
    {
        isBeeping = true;
        audioSource.Play(); // Comienza a reproducir el sonido
    }

    void StopBeeping()
    {
        isBeeping = false;
        audioSource.Stop(); // Detiene el sonido
    }
}