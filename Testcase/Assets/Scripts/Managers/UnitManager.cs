using UnityEngine;
using UnityEngine.InputSystem;
namespace Managers
{
    public class UnitManager : MonoBehaviour
    {
        [Header("Input Action References")]
        [SerializeField] private InputActionReference mousePositionActionReference;
        [SerializeField] private InputActionReference _moveActionReference;
        
        [Header("Parameters")]
        [SerializeField] private BaseUnit _selectedUnit;
        private Vector2 mousePosition;

        private void OnEnable()
        {
            _moveActionReference.action.Enable();
            mousePositionActionReference.action.Enable();
        }

        private void Awake()
        {
            EventManager.OnUnitSelected += OnUnitSelected;
            
            // Subscribe to the move action
            _moveActionReference.action.started += Move;
            _moveActionReference.action.performed += Move;
            _moveActionReference.action.canceled += Move;
            mousePositionActionReference.action.started += ReadMousePosition;
            mousePositionActionReference.action.performed += ReadMousePosition;
            mousePositionActionReference.action.canceled += ReadMousePosition;
        }

        private void ReadMousePosition(InputAction.CallbackContext obj)
        {
            mousePosition = obj.ReadValue<Vector2>();
        }

        private void Move(InputAction.CallbackContext obj)
        {
            if (_selectedUnit == null) return;

           Ray ray = Camera.main.ScreenPointToRay(mousePosition);
           if (Physics.Raycast(ray, out RaycastHit hit))
           {
               _selectedUnit.MoveStart(hit.point);
           }
        }

        private void OnUnitSelected(BaseUnit unit)
        {
            // Deselect the previously selected unit
            DeSelectPreviouslySelectedUnits();
            
            Debug.Log("Unit selected: " + unit.name);
            
            _selectedUnit = unit;
            if (_selectedUnit != null)
            {
                _selectedUnit.GetComponent<Renderer>().material.color = Color.white;
            }
        }

        private void DeSelectPreviouslySelectedUnits()
        {
            if (_selectedUnit != null)
            {
                _selectedUnit.GetComponent<Renderer>().material.color = _selectedUnit.MaterialColor;
            }
        }

        private void OnDisable()
        {
            _moveActionReference.action.Disable();
            mousePositionActionReference.action.Disable();
            EventManager.OnUnitSelected -= OnUnitSelected;
            
            // Unsubscribe from the move action
            _moveActionReference.action.started -= Move;
            _moveActionReference.action.performed -= Move;
            _moveActionReference.action.canceled -= Move;
            mousePositionActionReference.action.started -= ReadMousePosition;
            mousePositionActionReference.action.performed -= ReadMousePosition;
            mousePositionActionReference.action.canceled -= ReadMousePosition;
        }
    }
}
