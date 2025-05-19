using UnityEngine;
using UnityEngine.InputSystem;
namespace Controllers
{
    public class UnitController : MonoBehaviour
    {
        [SerializeField] private InputActionReference mousePositionActionReference;
        [SerializeField] private InputActionReference mouseClickActionReference;
        private Vector2 mousePosition;

        private void OnEnable()
        {
            mousePositionActionReference.action.Enable();
            mouseClickActionReference.action.Enable();
        }

        private void Awake()
        {
            mousePositionActionReference.action.performed += OnActionPerformed;
            mouseClickActionReference.action.performed += Click;
        }

        private void Click(InputAction.CallbackContext obj)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            Physics.Raycast(ray, out RaycastHit hit);
            Debug.Log("Clicked on " + hit.collider.gameObject.name);
        }

        private void OnActionPerformed(InputAction.CallbackContext obj)
        {
            mousePosition = obj.ReadValue<Vector2>();
        }

        private void OnDisable()
        {
            mousePositionActionReference.action.Disable();
            mouseClickActionReference.action.Disable();
        }
    }
}
