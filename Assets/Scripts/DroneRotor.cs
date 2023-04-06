using UnityEngine;

public class DroneRotor : MonoBehaviour
{
    
    private void Update()
    {
        transform.Rotate(new Vector3(0,1,0), Time.deltaTime*2000);
    }
}
