using TreeEditor;
using UnityEngine;
using static UnityEditor.U2D.ScriptablePacker;

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
        if (Input.GetKeyDown(KeyCode.W) && pos < 2)
        {
            pos++;
            transform.position = FlontTransform.position;
        }

        if (Input.GetKeyDown(KeyCode.S)&& pos > 0)
        {
            transform.position = BackTransform.position;
            pos--;
        }
        float input = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
            input = 1;
        if (Input.GetKey(KeyCode.RightArrow))
            input = -1;

        transform.RotateAround(TargetObject.transform.position, Vector3.up, input * speed * Time.deltaTime);
    }
}
