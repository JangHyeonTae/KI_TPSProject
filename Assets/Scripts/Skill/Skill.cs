using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(fileName = "SKill", menuName = "Skills/Skill", order = 0)]
public class Skill : ScriptableObject
{
    public int damage;
    public float cool;
    public float skillRange;
    public string skillName;
    public Sprite icon;
    public GameObject skillParticle;
    public float particleDelay;
    public float skillForwardRange;
}
