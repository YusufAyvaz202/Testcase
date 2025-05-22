using Interfaces;
public interface IWeapon
{
    public float Damage { get; set; }
    public float AttackSpeed { get; set; }
    public float AttackRange { get; set; }
    
    public void Attack(IDamageable target);
}
