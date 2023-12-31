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

	public static string GetWeaponUsingTrigger(GunData.WeaponSize weaponSize) {
		switch (weaponSize) {
			case GunData.WeaponSize.pistol:
			return "GunShot";
			case GunData.WeaponSize.rilfe:
			return "RilfeShot";
			case GunData.WeaponSize.shotgun:
			return "ShotgunShot";
			default:
			break;
		}
		return "";
	}
}
