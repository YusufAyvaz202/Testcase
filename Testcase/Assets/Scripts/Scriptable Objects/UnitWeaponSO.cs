using UnityEngine;

[CreateAssetMenu(fileName = "UnitWeaponData", menuName = "ScriptableObjects/UnitWeaponSO", order = 1)]
public class UnitWeaponSO : ScriptableObject
{
    public float Damage;
    public float AttackSpeed;
    public float AttackRange;
}