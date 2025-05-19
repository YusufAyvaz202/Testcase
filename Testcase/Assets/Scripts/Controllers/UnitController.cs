using Managers;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Controllers
{
    public class UnitController : MonoBehaviour
    {
        [Header("Input Action References")]
        [SerializeField] private InputActionReference mousePositionActionReference;
        [SerializeField] private InputActionReference mouseClickActionReference;
        
        [Header("Parameters")]
        private Vector2 mousePosition;

        private void OnEnable()
        {
            mousePositionActionReference.action.Enable();
            mouseClickActionReference.action.Enable();
        }

        private void Awake()
        {
            mousePositionActionReference.action.performed += ReadMousePosition;
            mouseClickActionReference.action.performed += SelectUnit;
        }

        private void SelectUnit(InputAction.CallbackContext obj)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            Physics.Raycast(ray, out RaycastHit hit);
            if (hit.collider.gameObject.TryGetComponent(out BaseUnit unit))
            {
                EventManager.OnUnitSelected?.Invoke(unit);
            }
        }

        private void ReadMousePosition(InputAction.CallbackContext obj)
        {
            mousePosition = obj.ReadValue<Vector2>();
        }

        private void OnDisable()
        {
            mousePositionActionReference.action.Disable();
            mouseClickActionReference.action.Disable();
            
            mousePositionActionReference.action.performed -= ReadMousePosition;
            mouseClickActionReference.action.performed -= SelectUnit;
        }
    }
}
