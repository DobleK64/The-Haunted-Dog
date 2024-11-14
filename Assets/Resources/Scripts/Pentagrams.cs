using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Pentagrams : MonoBehaviour
{
    [SerializeField] private float amountP;

    [SerializeField] private PentagramScore pentagrams;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<PlayerMovementRB>())
        {
            pentagrams.AddPentagrams(amountP);
            Destroy(gameObject);
        }
    }
}
