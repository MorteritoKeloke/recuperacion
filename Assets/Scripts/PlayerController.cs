using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PlayerController es un singleton
    public static PlayerController sharedInstance;

    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float rotationSpeed = 50.0f;

    private float horizontalInput, verticalInput;

    private float defaultLimit = 25;
    private float leftLimit, rightLimit, forwardLimit, backLimit;

    // Configuramos que PlayerController sea un singleton
    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Configuramos los límites de movimiento por defecto
        ChangeMovementLimits(-defaultLimit, defaultLimit, defaultLimit, -defaultLimit);
    }

    private void update()
    {
        Movement();
        KeepBetweenLimits();
    }

    private void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        // Rotamos con el eje horizontal
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);
        // Movemos con el eje vertical
        Translate(Vector3.forward * movementSpeed * Time.deltaTime * verticalInput);
    }

   
    // =========================================================================================================
    // Las siguientes funciones hacen referencia a los límites de movimiento
    // NO TIENEN ERRORES
    // =========================================================================================================
    
    // Función que se encarga de cambiar los límites izquierdo, derecho, frontal y trasero
    public void ChangeMovementLimits(float left, float right, float forward, float back)
    {
        leftLimit = left;
        rightLimit = right;
        forwardLimit = forward;
        backLimit = back;
    }

    // Función que se encarga de mantener al player entre los límites
    private void KeepBetweenLimits()
    {
        Vector3 pos = transform.position;

        if (pos.x < leftLimit)
        {
            transform.position = new Vector3(leftLimit, pos.y, pos.z);
            return;
        }
        
        if (pos.x > rightLimit)
        { 
            transform.position = new Vector3(rightLimit, pos.y, pos.z);
            return;
        }
        
        if (pos.z < backLimit)
        {
            transform.position = new Vector3(pos.x, pos.y, backLimit);
            return;
        }
        
        if (pos.z > forwardLimit)
        {
            transform.position = new Vector3(pos.x, pos.y, forwardLimit);
            return;
        }
    }
}
