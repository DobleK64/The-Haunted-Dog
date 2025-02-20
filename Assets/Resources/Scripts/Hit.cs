using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public List<GameObject> viewList;
    void Start()
    {
        viewList = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        viewList.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        viewList.Remove(other.gameObject);
    }
}
