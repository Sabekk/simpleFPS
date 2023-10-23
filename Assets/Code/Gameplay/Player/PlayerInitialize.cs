using System.Collections.Generic;
using UnityEngine;

public class PlayerInitialize : MonoBehaviour
{
    [SerializeField]List<string> weapons;

	private void Start () {
		foreach (var weaponName in weapons) {
			Weapon newWeapon = ObjectPool.Instance.GetFromPool (weaponName).GetComponent<Weapon> ();
			newWeapon.Initialize ();
			Events.Gameplay.Equipment.OnInitializeStartingWeapon.Invoke (newWeapon);
		}
	}
}
