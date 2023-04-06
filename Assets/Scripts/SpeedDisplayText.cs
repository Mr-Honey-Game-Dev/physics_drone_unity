using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SpeedDisplayText : MonoBehaviour
{
    [SerializeField] Rigidbody Drone;
    Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }
    private void Update()
    {
        if(Drone!=null)
        text.text = "Speed: " + ((int)Drone.velocity.magnitude).ToString()+"m/s";
    }
}
