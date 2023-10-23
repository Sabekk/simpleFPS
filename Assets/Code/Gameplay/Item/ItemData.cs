using UnityEngine;

public class ItemData : ScriptableObject {
	[Tooltip("Name of item")]
	public string itemName;
	[Tooltip("Visual present of item in UI")]
	public Sprite itemSprite;
}
