using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarHUD : FadingItemHUD {
	[SerializeField] Slider slider;

	public void UpdateStatus (float percentage) {
		timer = liveTime;
		slider.value = percentage;
	}

	public override void OnDispose () {
		Events.UI.SliderPreview.OnSliderRemoved.Invoke (this);
	}
}
