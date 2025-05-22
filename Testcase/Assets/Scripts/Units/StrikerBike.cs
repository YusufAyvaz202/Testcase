namespace Units
{
    public class StrikerBike : BaseUnit
    {
        void Awake()
        {
            Damage = unitWeaponSO.Damage;
            AttackSpeed = unitWeaponSO.AttackSpeed;
            AttackRange = unitWeaponSO.AttackRange;
        }
    }
}
