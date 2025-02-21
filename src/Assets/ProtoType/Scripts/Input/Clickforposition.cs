using UnityEngine;

public class Clickforposition : MonoBehaviour
{

    float widthClampMax = Screen.width;
    float heightClampMax = Screen.height;
    float ClampMin = 0;
    Vector3 Before1flamePosition = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Vector3.zero;
        Vector3 deltaPosition = Vector3.zero;

        if (Input.GetMouseButton(0))
        {

            mousePosition = Input.mousePosition;
            mousePosition.y = Mathf.Clamp(mousePosition.y, ClampMin, heightClampMax);
            mousePosition.x = Mathf.Clamp(mousePosition.x, ClampMin, widthClampMax);
            deltaPosition = mousePosition - Before1flamePosition;
            
        }

        if (deltaPosition.x > 0){   Debug.Log("âE");}
        else if (deltaPosition.x < 0) { Debug.Log("ç∂"); }
        

        if (deltaPosition.y > 0) { Debug.Log("è„"); }
        else if (deltaPosition.y < 0) { Debug.Log("â∫"); }

        Before1flamePosition = mousePosition;
       
    }
}
