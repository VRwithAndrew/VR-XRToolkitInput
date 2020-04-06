using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class OculusInput : MonoBehaviour
{
    public Text content = null;

    private XRController controller = null;

    private void Awake()
    {
        controller = GetComponent<XRController>();
    }

    private void Update()
    {
        CommonInput();
        // OculusTouch();
    }

    private void CommonInput()
    {
        string output = string.Empty;

        // A Button
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
            output += "A Pressed: " + primary + "\n";

        // B Button
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondary))
            output += "B Pressed: " + secondary + "\n";

        // Touchpad/Joystick touch
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out bool touch))
            output += "Touchpad/Joystick Touch: " + touch + "\n";

        // Touchpad/Joystick press
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool press))
            output += "Touchpad/Joystick Pressed: " + press + "\n";

        // Touchpad/Joystick position
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
            output += "Touchpad/Joystick Position: " + position + "\n";

        // Grip press
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool grip))
            output += "Grip Pressed: " + grip + "\n";

        // Grip amount
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripAmount))
            output += "Grip Amount: " + gripAmount + "\n";

        // Trigger press
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool trigger))
            output += "Trigger Pressed: " + trigger + "\n";

        // Index/Trigger amount
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerAmount))
            output += "Trigger: " + triggerAmount;

        content.text = output;
    }

    /*
    private void OculusTouch()
    {
        if (controller.inputDevice.TryGetFeatureValue(OculusUsages.thumbrest, out bool rest))
            print("Thumb Rest: " + rest);

        if (controller.inputDevice.TryGetFeatureValue(OculusUsages.indexTouch, out bool touch))
            print("Index Touch: " + touch);

        if (controller.inputDevice.TryGetFeatureValue(OculusUsages.thumbTouch, out bool touch))
            print("Thumb Touch: " + touch);
    }
    */
}
