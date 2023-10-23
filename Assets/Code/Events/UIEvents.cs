public class UIEvents {
	public ItemPresent ItemPreview { get; set; } = new ItemPresent ();
	public SliderPresent SliderPreview { get; set; } = new SliderPresent ();

	/// <summary>
	/// Present of items in UI
	/// </summary>
	public class ItemPresent {
		/// <summary>
		/// Callen when refreshing weapon preview
		/// </summary>
		public Events.Event<Item> OnRefreshItemPreview = new Events.Event<Item> ();
	}
	
	/// <summary>
	/// Present of sliders in UI
	/// </summary>
	public class SliderPresent {
		/// <summary>
		/// Callen when slider was removed
		/// </summary>
		public Events.Event<HealthBarHUD> OnSliderRemoved = new Events.Event<HealthBarHUD> ();
	}
}
