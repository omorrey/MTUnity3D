using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float gravityScale = 9.8f, speedScale = 1.5f, jumpForce = 1f, turnSpeed = 150f;
    private float verticalSpeed = 0f, mouseX = 0f, mouseY = 0f, currentAngleX = 0f;

    private CharacterController controller;
    [SerializeField] private Camera goCamera;

    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    private void RotateCharacter(){
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(0f, mouseX * turnSpeed * Time.deltaTime, 0f));
        currentAngleX += mouseY * turnSpeed * Time.deltaTime*-1f;
        currentAngleX = Mathf.Clamp(currentAngleX, -60f, 60f);
        goCamera.transform.localEulerAngles = new Vector3(currentAngleX, 0f, 0f);
    }

  private void MoveCharacter(){
    Vector3 velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
    velocity = transform.TransformDirection (velocity) * speedScale;
    if (controller.isGrounded) {
        verticalSpeed = 0f;
        if (Input.GetButton("Jump") ) {
            verticalSpeed = jumpForce;
        }
    }
    verticalSpeed -= gravityScale * Time.deltaTime;
    velocity.y = verticalSpeed;
    controller.Move(velocity * Time.deltaTime);
  
  }
    void Update()
    {
        RotateCharacter();
        MoveCharacter();
    }
}
