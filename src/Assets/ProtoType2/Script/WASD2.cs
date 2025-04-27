using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WASD2 : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] Camera Camera;
    [SerializeField] float MAX_Speed = 50f;
    [SerializeField] float Rotation_Speed = 0.25f;

    Rigidbody PlayerRB;
    Vector3 MAX_Speed_Vector;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = Player.GetComponent<Rigidbody>();
        MAX_Speed_Vector = new Vector3(1, 0, 1) * MAX_Speed;


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MoveDirection = (Player.transform.forward * Input.GetAxis("Vertical"));

        Player.transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Horizontal") * Rotation_Speed, Vector3.up);
        //Camera.transform.localRotation *= Quaternion.AngleAxis(Input.GetAxis("Horizontal") * 0.5f, Vector3.up);
        Camera.transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Horizontal") * -Rotation_Speed);
        MoveDirection.Normalize();
        MoveDirection *= MAX_Speed;

        MoveDirection.y = 0f;

        PlayerRB.AddForce((MoveDirection - PlayerRB.linearVelocity) * 0.05f);



    }
}
