using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target : MonoBehaviour {
	public abstract MaterialData.Type MaterialType { get; }
	public abstract bool Markable { get; }

	List<DamageMark> marks = new List<DamageMark> ();

	public void AddMark (DamageMark mark) {
		marks.Add (mark);
		mark.SetTargetParent (this);
	}

	public void RemoveMark (DamageMark mark) {
		marks.Remove (mark);
	}

	public void ReturnAllMarks () {
		for (int i = marks.Count - 1; i >= 0; i--)
			ObjectPool.Instance.ReturnToPool (marks[i]);

	}
}
