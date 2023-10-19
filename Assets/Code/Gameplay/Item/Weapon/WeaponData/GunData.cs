using UnityEngine;

[CreateAssetMenu (fileName = "Gun", menuName = "Weapon/Gun")]
public class GunData : WeaponData {
	public enum WeaponSize { pistol, rilfe, shotgun }
	public WeaponSize weaponSize;
	public int magazine;
	public int maxAmmountOfBullets;
	public int bulletsPerShot;
	public float dispersion;
	public float reloadTime;
}
