using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum HauntedCharacters //tipo enumerado, le puede poner nombres a los numeros
{
    LIAM,SAMANTHA
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public HauntedCharacters characterType;  //para escoger el personaje
    private void Awake()
    {
        if (!instance)// si instance no tiene info
        {
            instance = this; //si isma llega a la fiesta y ve que no hay nadie guapo isma se queda en la fiesta / instance se asigna a este objeto
            DontDestroyOnLoad(gameObject);// para que no se destruya en la carga de escenas
        }
        else // si ya hay alguin mas guapo antes que isma / si instance tiene info
        {
            Destroy(gameObject); // isma se va / se destruye el gameobject, para que no haya dos o mas gms en el juego
        }
    }
}
