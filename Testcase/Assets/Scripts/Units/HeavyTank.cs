namespace Units
{
    public class HeavyTank : BaseUnit
    {
        void Awake()
        {
            Damage = unitWeaponSO.Damage;
            AttackSpeed = unitWeaponSO.AttackSpeed;
            AttackRange = unitWeaponSO.AttackRange;
        }
    }
}
