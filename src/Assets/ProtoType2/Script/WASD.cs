using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{

    [SerializeField]GameObject Player;
    [SerializeField]Camera Camera;
    [SerializeField]float MAX_Speed = 50f;

    Rigidbody PlayerRB;
    Vector3 MAX_Speed_Vector;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = Player.GetComponent<Rigidbody>();
        MAX_Speed_Vector = new Vector3(1,0,1) * MAX_Speed;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MoveDirection = (Camera.transform.forward * Input.GetAxis("Vertical") 
            + Camera.transform.right * Input.GetAxis("Horizontal"));

        MoveDirection.Normalize();
        MoveDirection *= MAX_Speed;

        MoveDirection.y = 0f;

        PlayerRB.AddForce((MoveDirection - PlayerRB.linearVelocity) * 0.05f);



    }
}
