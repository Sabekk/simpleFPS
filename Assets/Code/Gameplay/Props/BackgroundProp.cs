using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundProp : Target
{
    [SerializeField] MaterialData.Type materialType;
    public override MaterialData.Type MaterialType => materialType;
    public override bool Markable => true;
    public override bool ShowHitValue => false;
}
