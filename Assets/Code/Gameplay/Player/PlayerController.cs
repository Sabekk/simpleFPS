using UnityEngine;

[RequireComponent (typeof (CharacterController))]
public class PlayerController : MonoBehaviour {

	[SerializeField] float walkSpeed;
	[SerializeField] float runSpeed;
	[SerializeField] float jumpPower;
	[SerializeField] float gravity;

	Animator animator;
	CharacterController characterController;
	PlayerEquipment equipment;
	bool isRuning;
	bool isShoting;
	bool isGrounded;
	bool centralFirstAttack;
	Vector2 direction = Vector3.zero;
	Vector3 moveDirection = Vector3.zero;
	Vector3 velocity = Vector3.zero;

	RaycastHit rayHit;
	Weapon CurrentWeapon => equipment != null ? equipment.EquipedWeapon : null;

	private void Awake () {
		animator = GetComponent<Animator> ();
		characterController = GetComponent<CharacterController> ();
		equipment = GetComponent<PlayerEquipment> ();
		Events.Gameplay.Move.OnJump += Jump;
		Events.Gameplay.Move.OnMoveInDirection += MoveInDirection;
		Events.Gameplay.Move.OnSprint += Sprint;
		Events.Gameplay.Weapon.OnShoting += Shoting;
		Events.Gameplay.Weapon.OnReload += Reload;
		Events.Gameplay.Equipment.OnItemEquiped += OnItemEquiped;
		Events.Gameplay.Weapon.OnReloaded += OnReloadFinish;

	}
	private void OnDestroy () {
		Events.Gameplay.Move.OnJump -= Jump;
		Events.Gameplay.Move.OnMoveInDirection -= MoveInDirection;
		Events.Gameplay.Move.OnSprint -= Sprint;
		Events.Gameplay.Weapon.OnShoting -= Shoting;
		Events.Gameplay.Weapon.OnReload -= Reload;
		Events.Gameplay.Equipment.OnItemEquiped -= OnItemEquiped;
		Events.Gameplay.Weapon.OnReloaded -= OnReloadFinish;
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
		isGrounded = Physics.Raycast (transform.position, Vector3.down, characterController.height * 0.5f + 0.2f);
		if (!isGrounded)
			velocity.y -= gravity * Time.deltaTime;
		characterController.Move (velocity * Time.deltaTime);
	}

	void TryShoot () {
		if (isShoting) {
			if (CurrentWeapon != null && CurrentWeapon.CanBeUsed) {
				CurrentWeapon.UseVisualisation ();
				for (int i = 0; i < CurrentWeapon.AttacksCount; i++) {
					CurrentWeapon.Use ();
					float xSpread = centralFirstAttack ? 0 : Random.Range (-CurrentWeapon.Spread, CurrentWeapon.Spread);
					float ySpread = centralFirstAttack ? 0 : Random.Range (-CurrentWeapon.Spread, CurrentWeapon.Spread);
					centralFirstAttack = false;
					if (Physics.Raycast (MainCamera.Instance.Camera.transform.position, MainCamera.Instance.Camera.transform.forward + new Vector3 (xSpread, ySpread), out rayHit, CurrentWeapon.AttackRange)) {
						Target target = rayHit.collider.gameObject.GetComponent<Target> ();
						if (target != null) {
							bool isConsistency = target.CheckTypeConsistency (CurrentWeapon.IntendedType);
							if (target is IDamagable damagable && damagable.IsAlive && isConsistency)
								damagable.TakeDamage (CurrentWeapon.Damage);
							if (target.Markable) {
								CurrentWeapon.MakeMark (target.MaterialType, rayHit.point, Quaternion.LookRotation (rayHit.normal), out DamageMark mark);
								if (mark)
									target.AddMark (mark);
							}
							if (target.ShowHitValue) {
								target.ShowHitInformation (isConsistency, CurrentWeapon.Damage, rayHit.point);
							}
						} else if (rayHit.collider != null)
							CurrentWeapon.MakeMark (MaterialData.Type.iron, rayHit.point, Quaternion.LookRotation (rayHit.normal), out DamageMark mark);
					}
				}
				animator.SetTrigger (CurrentWeapon.UsingAnimation);
			}
		}
	}


	void Jump () {
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
		centralFirstAttack = CurrentWeapon ? CurrentWeapon.CentralFirstAttack : true;
		this.isShoting = isShoting;
	}

	void OnItemEquiped (Item item, int currentWeaponId) {
		Shoting (false);
		animator.Rebind ();
	}
	void Reload () {
		if (CurrentWeapon != null) {
			if (CurrentWeapon.ActualState != Weapon.State.none)
				return;
			isShoting = false;
			if (CurrentWeapon is GunWeapon gun) {
				if (!gun.NeedReload)
					return;
				gun.StartReload ();
				animator.SetBool ("Reloading", true);
			}
		}
	}
	void OnReloadFinish () {
		animator.SetBool ("Reloading", false);
	}
}
