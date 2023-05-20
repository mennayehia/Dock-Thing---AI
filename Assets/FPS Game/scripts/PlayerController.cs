using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float lookSpeed = 2.0f;
    public float maxLookAngle = 80.0f;
    public float jumpForce = 500.0f;

    public GameObject gun;
    public GameObject camera;





    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        transform.Translate(movement * speed * Time.deltaTime);



        //transform.Rotate(Vector3.up, mouseX * lookSpeed);
        //Camera.main.transform.Rotate(Vector3.right, -mouseY * lookSpeed);

        float rotationX = transform.localEulerAngles.y + mouseX * lookSpeed;
        float rotationY = transform.localEulerAngles.x - mouseY * lookSpeed;
        rotationY = Mathf.Clamp(rotationY, -maxLookAngle, maxLookAngle);

        transform.localEulerAngles = new Vector3(rotationY, rotationX, 0.0f);

        gun.transform.position = camera.transform.position;
        gun.transform.rotation = camera.transform.rotation;

        if (Input.GetButtonDown("Fire1"))
        {
            gun.GetComponent<GunController>().Fire();
        }
    }
}
