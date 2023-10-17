using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Material", menuName = "Item/Material")]
public class MaterialData : ScriptableObject
{
    public enum Type { wood, glass, steel, iron, plastic }
    public Type type;
    public float durability;
}
