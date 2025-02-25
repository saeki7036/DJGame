using Unity.VisualScripting;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    
    [SerializeField]
    GameObject TargetObject;
    [SerializeField]
    float speed = 3f;

    int pos = 1;
    [SerializeField]
    Transform FlontTransform,BackTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {      
        float input = 0;//Clickforposition.inputvalue;
        if ((Input.GetKeyDown(KeyCode.W) || input  == 1)&& pos < 2)
        {
            if (SphereColCheck(transform.forward) == false)
            {
                pos++;
                transform.position = FlontTransform.position;
            }      
        }

        if ((Input.GetKeyDown(KeyCode.S) || input  == -1)&& pos > 0)
        {
            if (SphereColCheck(-transform.forward) == false)
            {
                transform.position = BackTransform.position;
                pos--;
            }
        }

        SphereColCheckSide(transform,true);
        SphereColCheckSide(transform,false);
        //if (Input.GetKey(KeyCode.LeftArrow))
        //    input = 1;
        //if (Input.GetKey(KeyCode.RightArrow))
        //    input = -1;

        //transform.RotateAround(TargetObject.transform.position, Vector3.up, input * speed * Time.deltaTime);
    }

    bool SphereColCheck(Vector3 forward)
    {
        int layerMask = LayerMask.GetMask("Obstacl");
        RaycastHit[] raycastHit =
        Physics.SphereCastAll(transform.position + Vector3.up, 1.5f,
                              forward, 2.0f,
                              layerMask);
        foreach(var hit in raycastHit)
        {     
            Debug.LogAssertion(hit.collider.name);
            return true;
        }
        return false;
    }

    public static bool SphereColCheckSide(Transform transforms,bool isright)
    {
        int layerMask = LayerMask.GetMask("Obstacl");
        RaycastHit[] raycastHit =
        Physics.SphereCastAll(transforms.position + Vector3.up, 1.5f,
                              transforms.right * (isright ? 1:-1),
                              2.0f,
                              layerMask);
        foreach (var hit in raycastHit)
        {
            if(hit.collider.name != null)
                Debug.LogAssertion((isright ? "âE" : "ç∂") + hit.collider.name);
            return true;
        }
        return false;
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireCube(transform.position + transform.forward * 2.0f, new Vector3(1.0f, 1.0f, 1.0f));
        Gizmos.DrawWireSphere(transform.position + transform.forward * 1.5f, 1.5f);
        Gizmos.DrawWireSphere(transform.position + transform.forward * -1.5f, 1.5f);
        Gizmos.DrawWireSphere(transform.position + transform.right * -1.5f, 1.5f);
        Gizmos.DrawWireSphere(transform.position + transform.right * 1.5f, 1.5f);
    }
}
