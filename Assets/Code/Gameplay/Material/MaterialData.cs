using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Material", menuName = "Item/Material")]
public class MaterialData : ScriptableObject {
	[System.Flags]
	public enum Type {
		wood = 1,
		stone = 2,
		steel = 4,
		iron = 8,
		sand = 16
	}
	public Type type;
	public float durability;
}
