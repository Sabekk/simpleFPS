using TMPro;
using UnityEngine;

public class FastItemSlot : ItemSlot
{
	[SerializeField] GameObject keyObject;
	[SerializeField] TMP_Text keyText;

	public void SetKeyValue (string key) {
		if (string.IsNullOrEmpty (key))
			keyObject.SetActive (false);
		else {
			keyObject.SetActive (true);
			keyText.text = key;
		}
	}
}
