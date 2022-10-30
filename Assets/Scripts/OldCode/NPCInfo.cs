using System;
using UnityEngine;

public enum UnitType
{
    Scout,
    Soldier,
}

[Serializable]
public class UnitNpcInfo
{
    public UnitType UnitType;
    public NPCInfo NpcInfo;
}

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC/Create New NPC", order = 54)]
public class NPCInfo : ScriptableObject
{
    public UnitType UnitType;
    
    public Sprite NpcImage;

    public int HealthCount = 3;

    public float MoveSpeed = 1;

    public AttackSettings AttackSettings;

    public GameObject DestroyedPrefab;

    public float TimeBetweenAttacks
    {
        get => AttackSettings.TimeBetweenAttacks;
    }

    public int DamageCount
    {
        get => AttackSettings.DamageCount;
    }

    public AudioClip AttackSound
    {
        get => AttackSettings.AttackSound;
    }
}