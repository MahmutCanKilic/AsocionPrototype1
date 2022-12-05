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
    [SerializeField] private Animator jumpPadAnimator;
    public bool isAir;
    Animator animPlayer;
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
        xMargin = 3;
        animPlayer = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        if (transform.position.y < 1)
        {
            animPlayer.SetBool("Air", false);
        }
        else
        {
            animPlayer.SetBool("Air", true);
        }
        bool onAir = FindObjectOfType<FuelManagement>().onAir;
        if (transform.position.y >= 11)
        {
            if (onAir)
            {
                isAir = true;
                rb.constraints = RigidbodyConstraints.FreezePositionY;
                rb.freezeRotation = true;
            }
            else
            {
                isAir = false;
                rb.constraints = RigidbodyConstraints.None;
                rb.freezeRotation = true;
            }
 
        }
        else
        {
            isAir = false;
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
}
