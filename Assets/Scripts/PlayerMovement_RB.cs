using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRB : MonoBehaviour
{
    public float speed, rotationSpeed, JumpForce, sphereRadius; //*, gravityScale*; rotationSpeed o MouseSense
    public string groundName;
    //public LayerMask groundMask;
    private Rigidbody rb;
    private float x, z, mouseX; //input
    private bool jumpPressed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //gravityScale = -Mathf.Abs(gravityScale); // menos el valor absoluto de la gravedad. Mathf = float
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        //jumpPressed = Input.GetAxis("Jump");
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpPressed = true;
        }
        RotatePlayer();
    }

    void RotatePlayer()
    {
        Vector3 rotation = new Vector3(0, mouseX, 0) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);
    }
    private void FixedUpdate()
    {
        ApplySpeed();
        ApplyJumpForce();
       
    }

    void ApplySpeed()
    {
        rb.velocity = (transform.forward * speed * z) + (transform.right * speed * x) + new Vector3(0, rb.velocity.y, 0);
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
        RaycastHit[] colliders = Physics.SphereCastAll(new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z), sphereRadius, Vector3.up);
        for(int i = 0; i < colliders.Length; i++)//recorremos elemento a elemento
        {
            //comprobamos si ese elemento es suelo
            if (colliders[i].collider.gameObject.layer == LayerMask.NameToLayer("Ground")                                                                                                                                                      )
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
