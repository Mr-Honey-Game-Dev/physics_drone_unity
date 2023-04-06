using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Drone : MonoBehaviour
{
    Rigidbody rg;

    [Header("Drone Characterstics")]
    [SerializeField] float verticalAccelaration = 1;
    [SerializeField] float rotationRange = 45;
    [SerializeField] float rotationSpeedY = 5;
    [SerializeField] float rotationSpeedXZ = 5;

    float horizontalInput;
    float verticalInput;
    float throttle;
    float gravity;

    Quaternion startRotation;
    Quaternion endRotation;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
        gravity = Physics.gravity.magnitude;
    }

    void Update()
    {
        TakeInput();      
    }

    private void FixedUpdate()
    {
        rg.AddForce((transform.up * rg.mass * gravity) + (transform.up * rg.mass * gravity * throttle));
        RotateDrone();
    }
    void RotateDrone() 
    {
        startRotation = transform.rotation;
        endRotation = (Quaternion.Euler(verticalInput * rotationRange, transform.rotation.eulerAngles.y+(horizontalInput*rotationSpeedY), -horizontalInput * rotationRange)) * Quaternion.identity;
        transform.rotation = Quaternion.Lerp(startRotation, endRotation, Time.deltaTime * 15);
    }

    void TakeInput() 
    {
       horizontalInput = Input.GetAxis("Horizontal");
       verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.M))
        {
            throttle = Mathf.Lerp(throttle, 1, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.N))
        {
            throttle = Mathf.Lerp(throttle, -1, Time.deltaTime);
        }
        else 
        {
            throttle = Mathf.Lerp(throttle, 0, Time.deltaTime*2);
        }
    }
}
