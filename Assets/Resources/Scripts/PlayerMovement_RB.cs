using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerMovementRB : MonoBehaviour
{
    public float walkingspeed, runingSpeed, aceleration, rotationSpeed, JumpForce, sphereRadius; //*, gravityScale*; rotationSpeed o MouseSense
    public string groundName;
    //public LayerMask groundMask;

    private Rigidbody rb;
    private float x, z, mouseX; //input
    private bool jumpPressed;
    private bool shiftPressed;
    private float currentSpeed;
    public KeyCode downKey;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; //Desaparece el cursor
        //gravityScale = -Mathf.Abs(gravityScale); // menos el valor absoluto de la gravedad. Mathf = float
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        shiftPressed = Input.GetKey(KeyCode.LeftShift);

        InterpolationSpeed();

        //jumpPressed = Input.GetAxis("Jump");
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            BoxCollider bc = rb.GetComponent<BoxCollider>();
            bc.size = new Vector2(bc.size.x, bc.size.y / 2);          
        }
        else if (Input.GetKeyUp(KeyCode.G))
        {
            BoxCollider bc = rb.GetComponent<BoxCollider>();
            bc.size = new Vector2(bc.size.x, bc.size.y * 2);
        }
        RotatePlayer();
    }

    public void InterpolationSpeed()
    {
        if (shiftPressed)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, runingSpeed, aceleration * Time.deltaTime);
        }
        else if (x != 0 || z != 0)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, walkingspeed, aceleration * Time.deltaTime);
        }
        else 
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, aceleration * Time.deltaTime);
        }
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    void RotatePlayer()
    {
        Vector3 rotation = new Vector3(0, mouseX, 0) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation); // Se aplica la rotacion, tiene numeros imaginarios
    }
    private void FixedUpdate()
    {
        ApplySpeed();
        ApplyJumpForce();
       
    }

    void ApplySpeed()
    {
        rb.velocity = (transform.forward * currentSpeed * z) + (transform.right * currentSpeed * x) + new Vector3(0, rb.velocity.y, 0);
        //Se aplica la rotacion, tiene numeros imaginarios.
        //*+ (transform.up * gravityScale)*/; GRAVEDAD CONSTANTE NO REALISTA.
        //rb.AddForce(transform.up * gravityScale); GRAVEDAD REALISTA.
        // + new Vector3(0, rb.velocity.y, 0); GRAVEDAD BASE DE UNITY, PUEDE AJUSTARSE EN EL EDITOR.
    }
    
    void ApplyJumpForce()
    {
        if (jumpPressed)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * JumpForce);
            jumpPressed = false;
        }
    }
    private bool IsGrounded()
    {
        Collider[] colliders = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z), sphereRadius);
        for(int i = 0; i < colliders.Length; i++)//recorremos elemento a elemento
        {
            //comprobamos si ese elemento es suelo
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer("Ground")                                                                                                                                                      )
            {
                return true;
            }
        }
        return false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z), sphereRadius);
    }
}
