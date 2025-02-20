using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
public class PlayerMovementRB : MonoBehaviour
{
    public float walkingspeed, runingSpeed, aceleration, rotationSpeed, JumpForce, sphereRadius; //*, gravityScale*; rotationSpeed o MouseSense
    public string groundName;
    public AudioClip walkClip, runClip;
    //public LayerMask groundMask;
    public float maxStamina = 100f;  // Máxima cantidad de estamina
    public float currentStamina;     // Estamina actual
    public float staminaDrainRate = 10f;  // Cuánto se gasta por segundo al correr
    public float staminaRechargeRate = 5f; // Cuánto se recarga por segundo cuando no se corre
    
    private Rigidbody rb;
    private float x, z, mouseX; //input
    private bool jumpPressed;
    private bool shiftPressed;
    private float currentSpeed, currentTime;
    
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
        currentTime += Time.deltaTime;
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        shiftPressed = Input.GetKey(KeyCode.LeftShift);

        InterpolationSpeed();
        HandleStamina();
        
        //jumpPressed = Input.GetAxis("Jump");
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
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
        if (shiftPressed && currentStamina > 0)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, runingSpeed, aceleration * Time.deltaTime);
            if (currentTime > 0.5f)
            {
                AudioManager.instance.PlayAudio(runClip, "runSound");
                currentTime = 0;
            }           
        }
        else if (x != 0 || z != 0)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, walkingspeed, aceleration * Time.deltaTime);
            if (currentTime > 1f)
            {
                AudioManager.instance.PlayAudio(walkClip, "walkSound");
                currentTime = 0;
            }        
        }
        else 
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, aceleration * Time.deltaTime);
        }
    }
    void HandleStamina()
    {
        // Si la estamina est?vacía, no permitir correr
        if (currentStamina <= 0)
        {
            shiftPressed = false;  
        }
        if (shiftPressed && currentStamina > 0)
        {
            // Si se est?presionando Shift, gastar estamina
            
            currentStamina -= staminaDrainRate * Time.deltaTime;
            
        }
        else if (!shiftPressed && currentStamina < maxStamina)
        {
            // Si no se est?presionando Shift, recargar estamina
            currentStamina += staminaRechargeRate * Time.deltaTime;
            
        }

        // Limitar la estamina para que no supere el valor máximo
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        GameManager.instance.AddStamina(currentStamina);
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
        //Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z), sphereRadius);
    }
}
