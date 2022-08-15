using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BackstoryCard", order = 2)]

public class BackstoryCard : ScriptableObject
{
    public int moralityCost;
    public int deathMultiplier;
}
