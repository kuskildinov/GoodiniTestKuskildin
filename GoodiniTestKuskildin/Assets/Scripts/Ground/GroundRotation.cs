using UnityEngine;

public class GroundRotation : MonoBehaviour
{
    private const int TouchPanelMultiply = 5;

    [SerializeField] private Transform _root;
    [SerializeField,Range(0,3)] private float _rotationSpeed;
    private IInput _input;
    private Joystick _joystick;
    TouchPanel _touchPanel;
    private float _horizontal;
    public void Initialize(IInput input, Joystick joystick,TouchPanel touchPanel)
    {
        _input = input;
        _joystick = joystick;
        _touchPanel = touchPanel;
        _rotationSpeed = 1;
    }

    private void Update()
    {
        ReadInput();        
    }

    private void FixedUpdate()
    {
        Rotation();
    }

    private void Rotation()
    {
        Vector3 rotationSpeed = new Vector3(0,_horizontal * _rotationSpeed, 0);
        _root.transform.rotation *= Quaternion.Euler(rotationSpeed);
    }

    private void ReadInput()
    {
        if(_input.JoystickHorizontal(_joystick) != 0)
        {
            _horizontal = _input.JoystickHorizontal(_joystick);
        }
        else if(_input.TouchPanelHorizontal(_touchPanel) != 0)
        {
            _horizontal = _touchPanel.TouchDelta * TouchPanelMultiply;
        }
        else
        {
            _horizontal = 0;
        } 
    }
}
