using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReference : MonoBehaviour
{
    public GameObject target;

    private void Start()
    {
        target = FindObjectOfType<PlayerMovementRB>().gameObject;
    }
}