using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PerroMostruo : MonoBehaviour
{
    private bool cruz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Cruz cruzComponent = other.gameObject.GetComponent<Cruz>();

        if (cruzComponent != null)
        {
            cruz = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Cruz cruzComponent = other.gameObject.GetComponent<Cruz>();

        if (cruzComponent != null)
        {
            cruz = false;
        }
    }
    //void Update()
    //{
    //    target.CompareTag("Cruz")
    //}
}
