using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float sensX;
    [SerializeField] float sensY;
    [SerializeField] Transform playerBody;

    float xRotation;

	private void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}

	private void Update () {
        float mouseX = Input.GetAxisRaw ("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw ("Mouse Y") * Time.deltaTime * sensY;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp (xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler (xRotation, 0f, 0f);
        playerBody.Rotate (Vector3.up * mouseX);
	}
}
