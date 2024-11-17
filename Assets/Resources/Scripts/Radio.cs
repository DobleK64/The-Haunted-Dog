using UnityEngine;

public class RadioController : MonoBehaviour
{
    public float detectionRadius = 5f; // Radio de detección
    public AudioClip beepSound; // Sonido del pitido
    private AudioSource audioSource; // Componente para reproducir el audio
    private bool isBeeping = false; // Para controlar si la radio esta pitando

    void Start()
    {
        // Agrega automaticamente un componente AudioSource al objeto si no existe
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = beepSound; // Asigna el sonido configurado en el inspector
        audioSource.loop = true; // Reproducir en bucle
    }

    void Update()
    {
        DetectPentagrams(); // Llama al metodo para detectar pentagramas en cada frame
    }

    void DetectPentagrams()
    {
        // Busca todos los objetos con la etiqueta "Pentagrama"
        GameObject[] pentagrams = GameObject.FindGameObjectsWithTag("Pentagram");
        foreach (GameObject pentagram in pentagrams)
        {
            // Calcula la distancia entre la radio y cada pentagrama
            float distance = Vector3.Distance(transform.position, pentagram.transform.position);
            // Verifica si el pentagrama está dentro del radio de deteccion
            if (distance < detectionRadius)
            {
                if (!isBeeping) // Si no esta pitando, empieza a pitar
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
        isBeeping = true; // Cambia el estado a "pitando"
        audioSource.Play(); // Comienza a reproducir el sonido
    }

    void StopBeeping()
    {
        isBeeping = false; // Cambia el estado a "no pitando"
        audioSource.Stop(); // Detiene el sonido
    }
}