using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PentagramScore : MonoBehaviour
{
    private float pentagrams;

    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMesh.text = pentagrams.ToString("0");
    }

    public void AddPentagrams(float addedP)
    {
        pentagrams += addedP;
    }
}
