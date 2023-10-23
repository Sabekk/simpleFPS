using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitDamageInformationHUD : FadingItemHUD {
	[SerializeField] TMP_Text value;

	public override void OnUpdate () {
		base.OnUpdate ();
		transform.position += Vector3.up * Time.deltaTime * 3;
	}
	public void SetValue (string newValue) {
		value.SetText (newValue);
	}
}
