using UnityEngine;
using UnityEngine.UI;

public class HeightText : MonoBehaviour
{

    [SerializeField] private Text heightText;
    [SerializeField] private Transform ground;
    [SerializeField] private Transform drone;

    private void Update()
    {
        if(heightText!=null && ground!=null && drone!=null )
        heightText.text = "Height above sea level: " + Mathf.Round((drone.position.y - ground.position.y)).ToString()+"m";
    }
}
