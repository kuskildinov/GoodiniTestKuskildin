using UnityEngine;

public class ActivateAllDisplays : CompositeRoot
{
    public override void Compose()
    {
        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
        }
    }
}
