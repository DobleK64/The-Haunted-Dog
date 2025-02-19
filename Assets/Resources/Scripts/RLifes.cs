using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class RLifes : MonoBehaviour
{
    private float  valor = -0.1f;
    private bool safe = false, action;
    private void Update()
    {
        action = safe;
    }
    private void OnTriggerEnter (Collider collision)
    {
        PlayerMovementRB PMComponent = collision.gameObject.GetComponent<PlayerMovementRB>();

        if (PMComponent != null)
        {
            GameManager.instance.AddLifes(valor);
        }        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Cruz CruzComponent = collision.gameObject.GetComponent<Cruz>();

        if (CruzComponent != null)
        {
            safe = true;           
        }
        else
        {
            safe = false;
        }
    }
    //public bool Safe()
    //{
    //    return safe;
    //    bool tf = safe;
    //}
}
