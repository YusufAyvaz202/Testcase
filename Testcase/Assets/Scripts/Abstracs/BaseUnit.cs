using UnityEngine;

public abstract class BaseUnit : MonoBehaviour, IWeapon
{
    [Header("Unit Stats")]
    [SerializeField] protected float _health;
    [SerializeField] protected float moveSpeed;
    
    [Header("Weapon Stats")]
    public float Damage { get; set; }
    public float AttackSpeed { get; set; }
    public float AttackRange { get; set; }

    public void Attack()
    {
        // Implement attack logic here
        Debug.Log("Attacking with weapon!");
    }
    
    public void Move(Vector3 direction)
    {
        // Implement movement logic here
        Debug.Log($"Moving in direction: {direction}");
    }
}
