using System.Collections;
using Interfaces;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class BaseUnit : MonoBehaviour, IWeapon
{
    [Header("Move & Attack Parameters")]
    private Vector3 targetPosition;
    private float remainingDistance;
    private bool isAttacking;
    private bool isMoving;

    [Header("Unit Stats")]
    [SerializeField] protected float _health;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected UnitWeaponSO unitWeaponSO;
    private readonly Color unSelectedColor = Color.yellow;
    private readonly Color selectedColor = Color.green;

    [Header("Properties")]
    public Color UnselectedColor => unSelectedColor;
    public Color SelectedColor => selectedColor;

    [Header("Components")]
    [SerializeField] private Rigidbody _rigidbody;

    [Header("Weapon Stats")]
    public float Damage { get; set; }
    public float AttackSpeed { get; set; }
    public float AttackRange { get; set; }

    public void Attack(IDamageable target)
    {
        // Implement attack logic here
        Debug.Log("Attacking with weapon!");
        StartCoroutine(nameof(Attacking), target);
    }

    private IEnumerator Attacking(IDamageable target)
    {
        while (isAttacking)
        {
            target.TakeDamage(Damage);
            yield return new WaitForSeconds(AttackSpeed);
        }
    }

    public void MoveStart(Vector3 direction, bool isTarget)
    {
        Debug.Log($"Moving in direction: {direction}");
        targetPosition = direction;
        if (isTarget)
        {
            remainingDistance = AttackRange;
            isAttacking = true;
        }
        else
        {
            remainingDistance = 0.1f;
            isAttacking = false;  
        }
        isMoving = true;
        transform.LookAt(new Vector3(targetPosition.x, transform.position.y, targetPosition.z));
    }

    private void Move()
    {
        if (isMoving)
        {
            Vector3 direction = (targetPosition - transform.position);
            direction.y = 0;
            float distance = Vector3.Distance(transform.position, targetPosition);

            if (distance > remainingDistance)
            {
                _rigidbody.MovePosition(transform.position + direction * (moveSpeed * Time.deltaTime));
            }
            else
            {
                isMoving = false;
            }
        }
    }

    private void Update()
    {
        Move();
    }
}
