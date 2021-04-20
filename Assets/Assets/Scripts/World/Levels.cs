using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Levels : ScriptableObject
{

    public enum LevelType
    {
        Skul,
        Chest,
        Shop,
        regular

    }
    public LevelType levelType;

    public int index;
    
}
