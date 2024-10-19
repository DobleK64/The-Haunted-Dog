using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterManager : MonoBehaviour      
{
    protected HauntedCharacters character; //variable protejida para los personajes
    protected SpriteRenderer rend;
    Animator animator;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();


        //programamos un if para elegir para la funcion del boton para elegir el personaje
        if (GameManager.instance.characterType == HauntedCharacters.LIAM)
        {
            //character = new HauntedCharacters.Liam();
        }
        else if (GameManager.instance.characterType == HauntedCharacters.SAMANTHA)
        {
            //character = new HauntedCharacters.Samantha();
        }
    }

    public void Liam()
    {

    }
    public void Samantha()
    {

    }
}
