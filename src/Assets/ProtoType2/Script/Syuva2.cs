using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;
using UnityEngine.UI;
public class Syuva2 : MonoBehaviour
{
    [SerializeField] GameObject CameraObject;
    [SerializeField] Rigidbody rb;//Player
    [SerializeField] float RotateSpeed = 10f;
    [SerializeField] float DashSpeed = 10f;
    [SerializeField] float WaitTime = 0.2f;
    [SerializeField] float MaxSpeed = 50f;
    [SerializeField] Text VelocityText;//���x�\��

    Vector3 Force => new Vector3()
    {
        x = transform.position.x - CameraObject.transform.position.x,
        y = 0f,
        z = transform.position.z - CameraObject.transform.position.z,

    }.normalized;

    float MousePost_X = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.forward * DashSpeed, ForceMode.Force);
    }

    private IEnumerator WaitSecond(float waitTime)
    {
        float BeforeSpeed = rb.linearVelocity.magnitude;
        rb.linearVelocity = Vector3.zero;
        yield return new WaitForSeconds(waitTime);
        Dash(BeforeSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        MousePost_X = Mathf.Clamp(Input.GetAxis("Mouse X"), -1, 1);

        CameraObject.transform.RotateAround(transform.position, Vector3.up, MousePost_X * RotateSpeed);
        
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(WaitSecond(WaitTime));
        }

        VelocityText.text = rb.linearVelocity.magnitude.ToString();
    }

    void Dash(float BeforeSpeed)
    {
        rb.AddForce(Force * (BeforeSpeed + DashSpeed), ForceMode.Impulse);
        StartCoroutine(Braking(WaitTime));
    }

    private IEnumerator Braking(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //Debug.Log(rb.velocity.magnitude.ToString());
        while (rb.linearVelocity.magnitude >= MaxSpeed)
        {
            rb.linearVelocity = new()
            {
                x = rb.linearVelocity.x * 0.995f,
                y = 0,
                z = rb.linearVelocity.z * 0.995f,
            };
            
            yield return null;
        }
    }
}
