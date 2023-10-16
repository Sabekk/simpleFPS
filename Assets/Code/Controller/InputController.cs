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
}
