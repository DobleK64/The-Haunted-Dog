using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cruz : MonoBehaviour
{
    public float speed;
    public float maxTime;
    private float currentTime;
    private Vector3 _dir;
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > maxTime)
        {
            currentTime = 0;
            gameObject.SetActive(false); // se "devuelve" a la pool 
        }
    }
    private void FixedUpdate()
    {
        _rb.velocity = speed * _dir;
    }

    public void SetDirection(Vector3 value)
    {
        _dir = value;
    }
}
