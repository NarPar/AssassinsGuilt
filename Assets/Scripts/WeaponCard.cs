using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponCard", order = 3)]

public class WeaponCard : ScriptableObject
{
    public int timeCost;
    public float chanceToKill;
}
