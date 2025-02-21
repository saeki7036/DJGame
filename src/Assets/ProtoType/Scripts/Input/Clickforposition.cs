using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Clickforposition : MonoBehaviour
{

    float widthClampMax = Screen.width;
    float heightClampMax = Screen.height;
    float ClampMin = 0;
    Vector3 Before1flamePosition = Vector3.zero;
    Vector3 mousePosition = Vector3.zero;

    float rotateDecrease = 0;   

    [SerializeField]GameObject circle;
    [SerializeField] int rotationAdjust = 100;

    int Y = 0;
    int X = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 deltaPosition = Vector3.zero;

        if(Input.GetMouseButtonDown(0))
        {
            Before1flamePosition = MouseClamp(Input.mousePosition);

        }

        if (Input.GetMouseButton(0))
        {

            mousePosition = MouseClamp(Input.mousePosition);

            Vector3 circleScreenPosition = Camera.main.WorldToScreenPoint(circle.transform.position);
            Debug.Log("dP : CP" + mousePosition + ":" + circleScreenPosition);

            if (mousePosition.x > circleScreenPosition.x)
            {
                deltaPosition = mousePosition - Before1flamePosition;

            }
            else
            {
                deltaPosition = (mousePosition - Before1flamePosition) * -1;
                
            }
            
            
            



        }

        if (Input.GetMouseButtonUp(0))
        {
            //rotateDecrease = 0;
        }

        if (deltaPosition.x > 25)
        { 
            Debug.Log("右");
            
        }
        else if (deltaPosition.x < -25) 
        {
            Debug.Log("左"); 
        }
        

        if (deltaPosition.y > 0) 
        {
            Y = 1;
            rotateDecrease = deltaPosition.y;
        }
        else if (deltaPosition.y < 0)
        {
            Y = 2;
            rotateDecrease = deltaPosition.y;
        }
        else
        {
            Y = 0;
            rotateDecrease *= 0.99f;
        }

        switch (Y)
        {
            case 1:
            case 2:

                circle.transform.rotation *= quaternion.RotateY(deltaPosition.y / rotationAdjust);
                break;

            case 0:

                circle.transform.rotation *= quaternion.RotateY(rotateDecrease / rotationAdjust);
                break;
        }



        //if (Input.GetMouseButtonUp(0))
        //{
        //    if (deltaPosition.x == 0 && deltaPosition.y == 0)
        //    {
        //        Debug.Log("タップ");
        //    }
        //}

        Before1flamePosition = mousePosition;
       
    }

    Vector3 MouseClamp(Vector3 mousePosition)
    {
        
        mousePosition.y = Mathf.Clamp(mousePosition.y, ClampMin, heightClampMax);
        mousePosition.x = Mathf.Clamp(mousePosition.x, ClampMin, widthClampMax);

        return mousePosition;
    }
}
