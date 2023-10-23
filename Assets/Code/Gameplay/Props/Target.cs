using System.Collections.Generic;
using UnityEngine;

public abstract class Target : MonoBehaviour {
	public abstract MaterialData.Type MaterialType { get; }
	public abstract bool Markable { get; }
	public abstract bool ShowHitValue { get; }

	List<DamageMark> marks = new List<DamageMark> ();

	const string HIT_INFORMATION = "HUD_hitInformation";

	public void AddMark (DamageMark mark) {
		marks.Add (mark);
		mark.SetTargetParent (this);
	}

	public void RemoveMark (DamageMark mark) {
		marks.Remove (mark);
	}
	public bool CheckTypeConsistency (MaterialData.Type type) {
		return !(type != 0 && (type & MaterialType) == 0);
	}
	public void ShowHitInformation (bool isConsistency, float damageValue, Vector3 position) {
		HitDamageInformationHUD hitInformation = ObjectPool.Instance.GetFromPool (HIT_INFORMATION).GetComponent<HitDamageInformationHUD> ();
		hitInformation.Initiliaze ();
		hitInformation.SetValue (isConsistency ? damageValue.ToString () : "0");
		hitInformation.transform.position = position;
	}

	public void ReturnAllMarks () {
		for (int i = marks.Count - 1; i >= 0; i--)
			ObjectPool.Instance.ReturnToPool (marks[i]);
	}
}
