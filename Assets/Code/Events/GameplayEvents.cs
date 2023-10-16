using UnityEngine;

public class GameplayEvents {
	/// <summary>
	/// Events of player moving
	/// </summary>
	public Moving Move { get; private set; } = new Moving ();
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
}
