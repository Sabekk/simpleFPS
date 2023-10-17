using UnityEngine;

[CreateAssetMenu (fileName = "Gun", menuName = "Weapon/Gun")]
public class GunData : WeaponData {
	public int magazine;
	public int maxAmmountOfBullets;
	public int bulletsPerShot;
	public float timeBetweenShots;
	public float range;
	public float dispersion;
	public float reloadTime;
}
