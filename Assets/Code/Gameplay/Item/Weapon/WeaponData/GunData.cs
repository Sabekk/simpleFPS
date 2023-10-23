using UnityEngine;

[CreateAssetMenu (fileName = "Gun", menuName = "Weapon/Gun")]
public class GunData : WeaponData {
	public enum WeaponSize { pistol, rilfe, shotgun }
	[Tooltip("Size of weapon for player. Using only for animations")]
	public WeaponSize weaponSize;
	[Tooltip("Maximal attacks count in one attack serie")]
	public int magazine;
	[Tooltip("Maximal attacks count")]
	public int maxAmmountOfBullets;
	[Tooltip("Time to restore attack count")]
	public float reloadTime;
}
