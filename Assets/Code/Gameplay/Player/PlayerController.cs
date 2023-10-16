using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CharacterController))]
public class PlayerController : MonoBehaviour {
	[SerializeField] float walkSpeed;
	[SerializeField] float runSpeed;
	[SerializeField] float jumpPower;
	[SerializeField] float gravity;

	Vector2 direction;
	bool isRuning;
	CharacterController characterController;
	Vector3 moveDirection = Vector3.zero;
	Vector3 velocity = Vector3.zero;

	private void Awake () {
		characterController = GetComponent<CharacterController> ();
		Events.Gameplay.Move.OnJump += Jump;
		Events.Gameplay.Move.OnMoveInDirection += MoveInDirection;
		Events.Gameplay.Move.OnSprint += Sprint;
	}
	private void OnDestroy () {
		Events.Gameplay.Move.OnJump -= Jump;
		Events.Gameplay.Move.OnMoveInDirection -= MoveInDirection;
		Events.Gameplay.Move.OnSprint += Sprint;
	}
	private void Update () {
		MovePlayer ();
	}

	void MovePlayer () {
		if (direction != Vector2.zero) {
			moveDirection = transform.right * direction.x + transform.forward * direction.y;
			characterController.Move (moveDirection * (isRuning ? runSpeed : walkSpeed) * Time.deltaTime);
		}

		velocity.y -= gravity * Time.deltaTime;
		characterController.Move (velocity * Time.deltaTime);
	}

	void Jump () {
		bool isGrounded = Physics.Raycast (transform.position, Vector3.down, characterController.height * 0.5f + 0.2f);
		if (isGrounded)
			velocity.y = Mathf.Sqrt (jumpPower * gravity);
	}

	void MoveInDirection (Vector2 direction) {
		this.direction = direction;
	}

	void Sprint (bool isSprinting) {
		isRuning = isSprinting;
	}
}
