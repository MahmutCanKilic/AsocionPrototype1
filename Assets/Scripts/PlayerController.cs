using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Touch touch;
    Camera mainCamera;
    public Rigidbody rb;
    [SerializeField] private float xMargin;
    [SerializeField] private float playerSpeedX = 300;
    [SerializeField] private float playerSpeed = 500;
    public bool jumpPad;
    bool onAir;
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
        xMargin = 3;
    }


    void FixedUpdate()
    {
        if (transform.position.y >= 11)
        {
            onAir = true;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.freezeRotation = true;
        }
        int xDir = 0;
        float angelY = transform.eulerAngles.y;
        if (Application.isEditor)
        {
            if (Input.GetKey(KeyCode.D))
            {
                xDir = 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                xDir = -1;
                //rb.constraints = RigidbodyConstraints.None;
                //rb.freezeRotation = true;
            }
        }
        else
        {
            if (Input.touches.Length > 0)
            {
                Vector3 touchPosition = Input.touches[0].position;
                touchPosition = mainCamera.ScreenToWorldPoint(touchPosition);
            }
            if (touch.position.x > 0)
            {
                xDir = 1;
            }
            else
            {
                xDir = -1;
            }
        }
        rb.AddRelativeForce(xDir * playerSpeedX * Time.deltaTime, 0, playerSpeed, ForceMode.VelocityChange);
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        float posX = transform.position.x;
        posX = Mathf.Clamp(posX, -xMargin, xMargin);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
        //Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, 12 * Time.deltaTime,0);
        //transform.rotation = Quaternion.LookRotation(newDirection);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JumpPad"))
        {
            rb.AddForce(Vector3.up * 10, ForceMode.VelocityChange);

            Debug.Log("Jump");
        }
    }
}
