using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class BaseUnit : MonoBehaviour, IWeapon
{
    [Header("Move Parameters")]
    private Vector3 targetPosition;
    private bool isMoving;

    [Header("Unit Stats")]
    [SerializeField] protected float _health;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Color materialColor;

    [Header("Properties")]
    public Color MaterialColor => materialColor;

    [Header("Components")]
    [SerializeField] private Rigidbody _rigidbody;

    [Header("Weapon Stats")]
    public float Damage { get; set; }
    public float AttackSpeed { get; set; }
    public float AttackRange { get; set; }

    public void Attack()
    {
        // Implement attack logic here
        Debug.Log("Attacking with weapon!");
    }

    public void MoveStart(Vector3 direction)
    {
        Debug.Log($"Moving in direction: {direction}");
        targetPosition = direction;
        isMoving = true;
    }

    private void Move()
    {
        if (isMoving)
        {
            Vector3 direction = (targetPosition - transform.position);
            direction.y = 0;
            float distance = Vector3.Distance(transform.position, targetPosition);

            if (distance > 0.1f)
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
