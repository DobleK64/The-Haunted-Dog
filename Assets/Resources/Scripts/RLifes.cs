using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class RLifes : MonoBehaviour
{
    private float  valor = -0.1f;
    private void OnTriggerEnter(Collider collision)
    {
        PlayerMovementRB PMComponent = collision.gameObject.GetComponent<PlayerMovementRB>();

        if (PMComponent != null)
        {
            GameManager.instance.AddLifes(valor);
        }
    }
}
