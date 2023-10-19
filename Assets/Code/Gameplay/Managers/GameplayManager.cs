using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : Singleton<GameplayManager> {
	public static string GetPropMarkName (Weapon.Type weaponType, MaterialData.Type materialType) {
		switch (weaponType) {
			case Weapon.Type.melee:
			break;
			case Weapon.Type.gun:
			switch (materialType) {
				case MaterialData.Type.wood:
				return "bulletImpact_wood";
				case MaterialData.Type.stone:
				return "bulletImpact_stone";
				case MaterialData.Type.steel:
				return "bulletImpact_steel";
				case MaterialData.Type.iron:
				return "bulletImpact_steel";
				case MaterialData.Type.sand:
				return "bulletImpact_sand";
				default:
				break;
			}
			break;
			default:
			break;
		}
		return "";
	}
}
