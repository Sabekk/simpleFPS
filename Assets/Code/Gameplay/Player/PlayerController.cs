using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CharacterController))]
public class PlayerController : MonoBehaviour {
	[SerializeField] float walkSpeed;
	[SerializeField] float runSpeed;
	[SerializeField] float jumpPower;
	[SerializeField] float gravity;

	bool isRuning;
	CharacterController characterController;
	Vector3 moveDirection = Vector3.zero;
	Vector3 velocity = Vector3.zero;

	private void Awake () {
		characterController = GetComponent<CharacterController> ();

	}
	private void Update () {
		MovePlayer ();
	}

	void MovePlayer () {
		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");
		moveDirection = transform.right * x + transform.forward * z;
		isRuning = Input.GetKey (KeyCode.LeftShift);
		characterController.Move (moveDirection * (isRuning ? runSpeed : walkSpeed) * Time.deltaTime);
				
		bool isGrounded = Physics.Raycast (transform.position, Vector3.down, characterController.height * 0.5f + 0.2f);
		if (Input.GetButtonDown ("Jump") && isGrounded)
			velocity.y = Mathf.Sqrt(jumpPower * gravity);
		else {
			if (!isGrounded)
				velocity.y -= gravity * Time.deltaTime;
		}
		velocity.y -= gravity * Time.deltaTime;

		characterController.Move (velocity  * Time.deltaTime);
	}


}
