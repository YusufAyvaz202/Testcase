using Interfaces;
using UnityEngine;
namespace Abstracs
{
    public class BaseBuilding : MonoBehaviour, IDamageable
    {
        [Header("Building Stats")]
        [SerializeField] protected float _health;
        private readonly Color destructionColor = Color.red;

        public void TakeDamage(float damage)
        {
            if (_health <= 0) return; 
            _health -= damage;
            if (_health <= 0)
            {
                _health = 0;
                DestroyBuilding();
            }
        }

        private void DestroyBuilding()
        {
            // Implement destruction logic here
            Debug.Log("Building destroyed!");
            GetComponent<MeshRenderer>().material.color = destructionColor;
            GetComponent<Collider>().enabled = false;
            enabled = false;
        }
    }
}
