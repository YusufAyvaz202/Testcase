using UnityEngine;
namespace Abstracs
{
    public class BaseBuilding : MonoBehaviour
    {
        [Header("Building Stats")]
        [SerializeField] protected float _health;

        protected void TakeDamage(float damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                DestroyBuilding();
            }
        }

        private void DestroyBuilding()
        {
            // Implement destruction logic here
            Debug.Log("Building destroyed!");
            Destroy(gameObject);
        }
    }
}
