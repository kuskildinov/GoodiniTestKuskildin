public class PanelInput : IInput
{
    public float JoystickHorizontal(Joystick joystick)
    {
        return joystick.Horizontal;
    }

    public float TouchPanelHorizontal(TouchPanel touchPanel)
    {
        return touchPanel.TouchDelta;
    }
}
