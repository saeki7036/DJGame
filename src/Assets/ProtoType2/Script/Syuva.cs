using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Syuva : MonoBehaviour
{

    [SerializeField]Rigidbody Player;//Player
    [SerializeField] Text VelocityText;//���x�\��
    [SerializeField] GameObject targetObject;

    [SerializeField] float Max_Speed = 20f;
    float MousePost_X = 0;
    float MousePost_Y = 0;

    bool Dash_Flag;
    // Start is called before the first frame update
    void Start()
    {
        Dash_Flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Player.linearVelocity.z < Max_Speed && Player.linearVelocity.z > -Max_Speed) 
        {
            if (Input.GetKey(KeyCode.W))
            {
                Player.AddForce(transform.forward * 1.0f, ForceMode.Force);
            }
        }
        else
        {
            Player.linearVelocity = new Vector3(Player.linearVelocity.x, Player.linearVelocity.y, Player.linearVelocity.z * 0.99f);
        }

        if (Player.linearVelocity.x < Max_Speed && Player.linearVelocity.x > -Max_Speed)
        {
            if (Input.GetKey(KeyCode.A))
            {
                Player.AddForce(-transform.right * 1.0f, ForceMode.Force);
            }

            if (Input.GetKey(KeyCode.D))
            {
                Player.AddForce(transform.right * 1.0f, ForceMode.Force);
            }
        }
        else
        {
            Player.linearVelocity = new Vector3(Player.linearVelocity.x * 0.99f, Player.linearVelocity.y, Player.linearVelocity.z);
        }
        /*
        if (Player.velocity.x > 10.0f)
        {
            Player.velocity = new Vector3(10.0f, Player.velocity.y,Player.velocity.z);
        }
        if (Player.velocity.x < -10.0f)
        {
            Player.velocity = new Vector3(-10.0f, Player.velocity.y, Player.velocity.z);
        }
        if (Player.velocity.z > 10.0f)
        {
            Player.velocity = new Vector3(Player.velocity.x, Player.velocity.y, 10.0f);
        }
        if (Player.velocity.z < -10.0f)
        {
            Player.velocity = new Vector3(Player.velocity.x, Player.velocity.y, -10.0f);
        }
        */
        MousePost_X = Mathf.Clamp(Input.GetAxis("Mouse X"),-1,1);
        MousePost_Y = Mathf.Clamp(Input.GetAxis("Mouse Y"), -1, 1);

        Vector2 MousePost = new Vector2(MousePost_X, MousePost_Y).normalized;
        Vector3 Force = new Vector3(MousePost.x + transform.forward.x, 0f, MousePost.y + transform.forward.z).normalized;

        bool MousePostCheck = (Mathf.Abs(MousePost_X) == 1 || Mathf.Abs(MousePost_Y) == 1);

        if (MousePostCheck && Dash_Flag == false)
        {
            Player.AddForce(Force * Max_Speed, ForceMode.Impulse);
            Dash_Flag = true;
        }
        else if(!MousePostCheck && Dash_Flag == true)
            Dash_Flag = false;

        Vector3 velocity = Player.linearVelocity;
        Vector3 Look = new(velocity.x, 0, velocity.z);


        targetObject.transform.localPosition = Look.normalized;

        if (Look.sqrMagnitude > 0.01f)
        {
            Quaternion target = Quaternion.LookRotation(new Vector3(targetObject.transform.localPosition.x, 0, targetObject.transform.localPosition.z));
            //Quaternion.Lerp(Player.transform.rotation, target,1f);
            Player.transform.rotation = target;
            
        }

        VelocityText.text ="x:" + Player.linearVelocity.x.ToString() + "\nz:" +Player.linearVelocity.z.ToString();

        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.position = new()
            {
                x = 0,
                y = transform.position.y,
                z = 0
            };
        }
    }
}
