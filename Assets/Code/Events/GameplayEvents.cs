using UnityEngine;

public class GameplayEvents {
	/// <summary>
	/// Events of player moving
	/// </summary>
	public Moving Move { get; private set; } = new Moving ();
	public Equipment Eq { get; private set; } = new Equipment ();
	public class Moving {
		/// <summary>
		/// Called when player jump
		/// </summary>
		public Events.Event OnJump = new Events.Event ();
		/// <summary>
		/// Called when player make move
		/// </summary>
		public Events.Event<Vector2> OnMoveInDirection = new Events.Event<Vector2> ();
		/// <summary>
		/// Called when player look around
		/// </summary>
		public Events.Event<Vector2> OnLookInDirection = new Events.Event<Vector2> ();
		/// <summary>
		/// Called when player change walk speed
		/// </summary>
		public Events.Event<bool> OnSprint = new Events.Event<bool> ();
	}
	/// <summary>
	/// Events of player equipment
	/// </summary>
	public class Equipment {
		/// <summary>
		/// Called when player picking new weapon
		/// </summary>
		public Events.Event<Weapon> OnAddWeapon = new Events.Event<Weapon> ();
		/// <summary>
		/// Called when player switching weapon to current id
		/// </summary>
		public Events.Event<int> OnSwitchWeapon = new Events.Event<int> ();
		/// <summary>
		/// Called when player switching to next weapon
		/// </summary>
		public Events.Event OnSwitchToNextWeapon = new Events.Event ();
		/// <summary>
		/// Called when player switching to previous weapon
		/// </summary>
		public Events.Event OnSwitchToPreviousWeapon = new Events.Event ();
	}
}
