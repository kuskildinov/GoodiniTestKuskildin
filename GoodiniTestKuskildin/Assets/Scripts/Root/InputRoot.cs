using UnityEngine;

public class InputRoot : CompositeRoot
{
    [SerializeField] private GroundRotation _groundRotation;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private TouchPanel _touchPanel;
    [SerializeField] private ButtonsPanel _buttonPanel;

    public override void Compose()
    {
        IInput input = new PanelInput();
        _groundRotation.Initialize(input,_joystick, _touchPanel);
        _buttonPanel.Initialize();
    }
}
