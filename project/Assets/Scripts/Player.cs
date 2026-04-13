using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 5f;
    public float mouseSensitivity = 100f;

    public float gravity = -9.81f;
    public float groundedYVelocity = -2f;

    private float yVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (controller.isGrounded && yVelocity < 0)
        {
            yVelocity = groundedYVelocity;
        }

        yVelocity += gravity * Time.deltaTime;

        Vector3 velocity = move * speed;
        velocity.y = yVelocity;

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("L2 Trigger"))
        {
            SceneManager.LoadScene(2);
        }
    }
}