using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Touch touch;
    Camera mainCamera;
    Rigidbody rb;
    [SerializeField] private float xMargin;
    [SerializeField] private float playerSpeedX = 300;
    [SerializeField] private float playerSpeed = 500;
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
        xMargin = 3;
    }


    void FixedUpdate()
    {
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
        Vector3 direction = new Vector3(xDir * playerSpeedX * Time.deltaTime, 0, playerSpeed);
        rb.velocity = direction;
        float posX = transform.position.x;
        posX = Mathf.Clamp(posX, -xMargin, xMargin);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
        //Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, 12 * Time.deltaTime,0);
        //transform.rotation = Quaternion.LookRotation(newDirection);

    }
}
