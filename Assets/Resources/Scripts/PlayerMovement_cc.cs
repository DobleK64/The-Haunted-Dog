using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]//Es obligatorio que tenga el componente si no lo tiene, lo pone automaticamente.
public class PlayerMovement_cc : MonoBehaviour
{
    public float speed, rotationSpeed, gravityScale, jumpForce;

    private float yVelocity = 0;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        gravityScale = Mathf.Abs(gravityScale);
    }

    // Update is called once per frame
    void Update()
    {
        if(characterController.isGrounded)
        {
            yVelocity = 0;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);

        Jump(jumpPressed);
        Movement(x, z);
        //Rotation(mouseX);

    }

    void Jump(bool jumpPressed)
    {
        //Salto
        if (jumpPressed && characterController.isGrounded)
        {
             yVelocity += Mathf.Sqrt(jumpForce * 3 * gravityScale);
            //Vector3 jumpVector = transform.up * jumpForce * Time.deltaTime;
            //characterController.Move(jumpVector);
        }
    }

    void Movement(float x, float z)
    {
        Vector3 movementVector = transform.forward * speed * z + transform.right * speed * x; //Vector de movimiento
        yVelocity -= gravityScale; //La y velocity es negativa (gravedad)
        movementVector.y = yVelocity;//A NUESTRO VECTOR DE MOVIMIENTO LE ESTABLECEMOS LA GRAVEDAD (LA Y)

        movementVector *= Time.deltaTime; //para que se mueva a la misma velocidad independientemente del framerate del PC
        characterController.Move(movementVector); //metodo que tiene el componeete charactercontroller para que se muevan los objetos
    }

    void Rotation(float mouseX)
    {
        //Rotation
        Vector3 rotation = new Vector3(0, mouseX, 0) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);
    }
}
