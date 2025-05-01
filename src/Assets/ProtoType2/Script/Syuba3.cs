using Unity.VisualScripting;
using UnityEngine;

public class Syuba3 : MonoBehaviour
{
    [SerializeField] float Max_Speed = 20f;

    [SerializeField] float moveSpeed = 5f;
    public float rotationSpeed = 720f; // 回転速度（度/秒）

    private Rigidbody rb;
    private Vector3 moveDirection ()
    {
        Vector3 Direction;
        // カメラの向きに対して相対的に移動方向を決める
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        Direction = forward * v + right * h;
        Direction.y = 0f;
        return Direction;
    }

    float h = 0;
    float v = 0;
    private bool MouseInput = false;
    bool MousePostCheck = false;
    bool LeftClick = true;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.AddForce(transform.forward * moveSpeed, ForceMode.Force);
    }

    void Update()
    {
        RetryButton();

        if (Input.GetMouseButtonUp(0))
            LeftClick = true;

        if (Input.GetMouseButton(0))
        {
            h = Mathf.Clamp(Input.GetAxis("Mouse X"), -1, 1);
            v = Mathf.Clamp(Input.GetAxis("Mouse Y"), -1, 1);
        }

        MousePostCheck = (Mathf.Abs(h) >= 1 || Mathf.Abs(v) >= 1);

       
        if (MousePostCheck && !MouseInput)
        {
            MouseInput = true;
                return;
        }
        MouseInput = false;
    }

    void RetryButton()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.position = new()
            {
                x = 0,
                y = transform.position.y,
                z = 0
            };

            rb.linearVelocity = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        // Rigidbodyで移動
        if (MousePostCheck && LeftClick)
        {
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(/*rb.position +*/ moveDirection().normalized * Max_Speed, ForceMode.Impulse);

            if (moveDirection().sqrMagnitude > 0.001f)
            {
                // 移動方向に回転させる
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection());
                //Quaternion target = Quaternion.LookRotation(new Vector3(targetObject.transform.localPosition.x, 0, targetObject.transform.localPosition.z));
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
                transform.rotation = targetRotation;
            }
            LeftClick = false;
        }


        DeGainZ();
        DeGainX();
    }

    void DeGainZ()
    {
        if (rb.linearVelocity.z < Max_Speed && rb.linearVelocity.z > -Max_Speed)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(transform.forward * moveSpeed, ForceMode.Force);
            }
        }
        else
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, rb.linearVelocity.z * 0.99f);
        }

    }
    void  DeGainX()
    {

        if (rb.linearVelocity.x < Max_Speed && rb.linearVelocity.x > -Max_Speed)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(-transform.right * moveSpeed, ForceMode.Force);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(transform.right * moveSpeed, ForceMode.Force);
            }
        }
        else
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x * 0.99f, rb.linearVelocity.y, rb.linearVelocity.z);
        }
    }
}
