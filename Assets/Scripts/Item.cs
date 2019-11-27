using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = -999)]
public class Item : ScriptableObject
{
    [Min(1)]
    public int sizeX;
    [Min(1)]
    public int sizeY;
    public Color color;
}
