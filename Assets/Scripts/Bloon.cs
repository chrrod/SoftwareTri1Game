using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBloon", menuName = "Bloon")]
public class Bloon : ScriptableObject
{
    public int health;
    public int damage;
    public Sprite bloon;
    public int value;
}
