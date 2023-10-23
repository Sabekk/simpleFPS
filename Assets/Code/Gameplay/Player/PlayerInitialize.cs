using System.Collections.Generic;
using UnityEngine;

public class PlayerInitialize : MonoBehaviour
{
    List<string> allWeapons;
	private void Awake () {
		allWeapons = new List<string> ();
	}
	private void OnDestroy () {
		allWeapons.Clear ();
	}

	private void Start () {
		ObjectPool.Instance.GetAllPoolsOfType ("Weapon", ref allWeapons);
		foreach (var weaponName in allWeapons) {
			Weapon newWeapon = ObjectPool.Instance.GetFromPool (weaponName).GetComponent<Weapon> ();
			newWeapon.Initialize ();
			Events.Gameplay.Eq.OnInitializeStartingWeapon.Invoke (newWeapon);
		}
	}
}
