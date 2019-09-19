using UnityEngine;
using System.Collections;

public enum DungeonType {
    Magic, Strength, Speed
}

public class Dungeon : MonoBehaviour {
    public DungeonType Type;
    public string Name;
    public Stats Stats;
}
