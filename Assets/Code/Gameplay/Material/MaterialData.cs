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

	[Tooltip ("Material type")]
	public Type type;
	[Tooltip ("Maximal health of material")]
	public float durability;
}
