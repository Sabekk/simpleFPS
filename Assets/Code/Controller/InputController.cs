using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour, InputBinds.IPlayerActions {
	static InputBinds _controll;
	public static InputBinds Input {
		get {
			if (_controll == null)
				_controll = new InputBinds ();
			return _controll;
		}
	}

	private void Awake () {
		Input.Player.SetCallbacks (this);
	}

	void OnEnable () {
		Input.Enable ();
	}

	void OnDisable () {
		Input.Disable ();
	}

	public void OnJump (InputAction.CallbackContext context) {
		if (context.performed)
			Events.Gameplay.Move.OnJump.Invoke ();
	}

	public void OnMovement (InputAction.CallbackContext context) {
		if (!context.started)
			Events.Gameplay.Move.OnMoveInDirection.Invoke (context.ReadValue<Vector2> ());
	}

	public void OnLookAround (InputAction.CallbackContext context) {
		if (!context.started)
			Events.Gameplay.Move.OnLookInDirection.Invoke (context.ReadValue<Vector2> ());
	}

	public void OnSprint (InputAction.CallbackContext context) {
		if (context.started)
			Events.Gameplay.Move.OnSprint.Invoke (true);

		if (context.canceled)
			Events.Gameplay.Move.OnSprint.Invoke (false);
	}

	public void OnWeapon1 (InputAction.CallbackContext context) {
		if (context.started)
			Events.Gameplay.Eq.OnSwitchWeapon.Invoke (0);
	}

	public void OnWeapon2 (InputAction.CallbackContext context) {
		if (context.started)
			Events.Gameplay.Eq.OnSwitchWeapon.Invoke (1);
	}

	public void OnWeapon3 (InputAction.CallbackContext context) {
		if (context.started)
			Events.Gameplay.Eq.OnSwitchWeapon.Invoke (2);
	}

	public void OnWeapon4 (InputAction.CallbackContext context) {
		if (context.started)
			Events.Gameplay.Eq.OnSwitchWeapon.Invoke (3);
	}

	public void OnWeapon5 (InputAction.CallbackContext context) {
		if (context.started)
			Events.Gameplay.Eq.OnSwitchWeapon.Invoke (4);
	}

	public void OnNextWeapon (InputAction.CallbackContext context) {
		if (context.started)
			Events.Gameplay.Eq.OnSwitchToNextWeapon.Invoke ();
	}

	public void OnPreviousWeapon (InputAction.CallbackContext context) {
		if (context.started)
			Events.Gameplay.Eq.OnSwitchToPreviousWeapon.Invoke ();
	}

	public void OnShot (InputAction.CallbackContext context) {
		if (context.started)
			Events.Gameplay.Weapon.OnShoting.Invoke (true);
		if (context.canceled)
			Events.Gameplay.Weapon.OnShoting.Invoke (false);
	}
}
