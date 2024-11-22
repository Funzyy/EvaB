using UnityEngine;
using UnityEngine.InputSystem; // Wichtig für das neue System

public class PCMovement : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 100f;

    private Vector2 moveInput; // Bewegungseingabe
    private Vector2 lookInput; // Mausbewegung
    private float xRotation = 0f;

    public Transform cameraTransform;

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    void Update()
    {
        MovePlayer();
        RotateCamera();
    }

    void MovePlayer()
    {
        Vector3 movement = transform.right * moveInput.x + transform.forward * moveInput.y;
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    void RotateCamera()
    {
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }
}
