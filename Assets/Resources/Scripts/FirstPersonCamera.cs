using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float rotationSpeed, CameraLim;
    public Transform playerTransform;

    private float mouseYRotation;
 
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Desaparece el cursor
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        mouseYRotation -= mouseY;

        if (CameraLim < mouseYRotation || -CameraLim > mouseYRotation)
        {
            mouseYRotation = Mathf.Clamp(mouseYRotation, -CameraLim, CameraLim);
        }
        else 
        { 
            transform.localEulerAngles = Vector3.right * mouseYRotation;
        }

        playerTransform.Rotate(Vector3.up * mouseX); //es lo mismo que new vector3 (0,mousex, 0)" que esta en el script de  CC
    }
}
