using UnityEngine;

public class GameplayEvents {
	public Moving Move { get; private set; } = new Moving ();
	public Equipment Eq { get; private set; } = new Equipment ();
	public WeaponAction Weapon { get; private set; } = new WeaponAction ();

	/// <summary>
	/// Events of player moving
	/// </summary>
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
		/// Called for initialzie starting weapon
		/// </summary>
		public Events.Event<Weapon> OnInitializeStartingWeapon = new Events.Event<Weapon> ();
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
		/// <summary>
		/// Called when player switched weapon
		/// </summary>
		public Events.Event<Item, int> OnItemEquiped = new Events.Event<Item, int> ();
		/// <summary>
		/// Called when player equiped new weapon
		/// </summary>
		public Events.Event<Weapon, int> OnAddedNewWeapon = new Events.Event<Weapon, int> ();
	}
	/// <summary>
	/// Called when player using weapon
	/// </summary>
	public class WeaponAction {
		/// <summary>
		/// Called when player start or stop shooting
		/// </summary>
		public Events.Event<bool> OnShoting = new Events.Event<bool> ();
		/// <summary>
		/// Called when player reloading weapon
		/// </summary>
		public Events.Event OnReload = new Events.Event ();
		/// <summary>
		/// Called for updating current specialAction
		/// </summary>
		public Events.Event<float> OnUpdateSpecialAction = new Events.Event<float> ();
	}

}
