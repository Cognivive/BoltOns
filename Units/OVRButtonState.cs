using Bolt;
using Ludiq;

namespace Cognivive.Bolt.Units
{
    [TypeIcon(typeof(OVRButtonState))] // Choose the type icon. @32x - headers; @16x -ports and fuzzy finder categories. Located in Editor Default Resources.
    [UnitTitle("Get Button State")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    [UnitCategory("OVR")] // Sets unit category in Fuzzy Finder. Subfolders are matched and created.
    public class OVRButtonState : Unit
    {
        [DoNotSerialize] public ValueInput Hand;

        [DoNotSerialize] public ValueInput Button;

        [DoNotSerialize] public ValueOutput Value;

        protected override void Definition()
        {
            Value = ValueOutput<bool>("Value", GetValue);
            Hand = ValueInput<OVRInput.Controller>("Hand", OVRInput.Controller.All);
            Button = ValueInput<OVRInput.Button>("Button", OVRInput.Button.Any);
        }

        private bool GetValue(Recursion arg1)
        {
            return OVRInput.Get(Button.GetValue<OVRInput.Button>(), Hand.GetValue<OVRInput.Controller>());
        }
    }
}