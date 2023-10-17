using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CharacterController))]
public class PlayerController : MonoBehaviour {

	[SerializeField] Camera camera;
	[SerializeField] float walkSpeed;
	[SerializeField] float runSpeed;
	[SerializeField] float jumpPower;
	[SerializeField] float gravity;

	CharacterController characterController;
	PlayerEquipment equipment;
	bool isRuning;
	bool isShoting;
	Vector2 direction = Vector3.zero;
	Vector3 moveDirection = Vector3.zero;
	Vector3 velocity = Vector3.zero;

	RaycastHit rayHit;
	IDamageable lastTarget;
	Weapon currentWeapon => equipment != null ? equipment.EquipedWeapon : null;

	private void Awake () {
		characterController = GetComponent<CharacterController> ();
		equipment = GetComponent<PlayerEquipment> ();
		Events.Gameplay.Move.OnJump += Jump;
		Events.Gameplay.Move.OnMoveInDirection += MoveInDirection;
		Events.Gameplay.Move.OnSprint += Sprint;
		Events.Gameplay.Weapon.OnShoting += Shoting;

	}
	private void OnDestroy () {
		Events.Gameplay.Move.OnJump -= Jump;
		Events.Gameplay.Move.OnMoveInDirection -= MoveInDirection;
		Events.Gameplay.Move.OnSprint -= Sprint;
		Events.Gameplay.Weapon.OnShoting -= Shoting;
	}
	private void Update () {
		MovePlayer ();
		TryShoot ();
	}

	void MovePlayer () {
		if (direction != Vector2.zero) {
			moveDirection = transform.right * direction.x + transform.forward * direction.y;
			characterController.Move (moveDirection * (isRuning ? runSpeed : walkSpeed) * Time.deltaTime);
		}

		velocity.y -= gravity * Time.deltaTime;
		characterController.Move (velocity * Time.deltaTime);
	}

	void TryShoot () {
		if (isShoting) {
			if (currentWeapon != null && currentWeapon.CanBeUsed) {
				currentWeapon.Use ();
				if (Physics.Raycast (camera.transform.position, camera.transform.forward, out rayHit, currentWeapon.AttackRange, LayerMask.GetMask ("Damagable"))) {
					IDamageable damagable = rayHit.collider.gameObject.GetComponent<IDamageable> ();
					if (damagable != null) {
						damagable.TakeDamage (currentWeapon.Damage);
					}
				}
			}
		}
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

	void Shoting (bool isShoting) {
		this.isShoting = isShoting;
	}
}
