public class UIEvents {
	/// <summary>
	/// Events of weapon preview
	/// </summary>
	public ItemPresent ItemPreview { get; set; } = new ItemPresent ();
	public class ItemPresent {
		/// <summary>
		/// Callen when refreshing weapon preview
		/// </summary>
		public Events.Event<Item> OnRefreshItemPreview = new Events.Event<Item> ();
	}
}
