using Bolt;
using Ludiq;

namespace Core.Cognivive.Bolt.Units
{
    [TypeIcon(typeof(OVRControlAxisValue))] // Choose the type icon. @32x - headers; @16x -ports and fuzzy finder categories. Located in Editor Default Resources.
    [UnitTitle("Get Control Axis Value")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    [UnitCategory("OVR")] // Sets unit category in Fuzzy Finder. Subfolders are matched and created.
    public class OVRControlAxisValue : Unit
    {
        [DoNotSerialize] public ValueInput Hand;

        [DoNotSerialize] public ValueInput Axis;

        [DoNotSerialize] public ValueOutput Value;

        protected override void Definition()
        {
            Value = ValueOutput<float>("Value", GetValue);
            Hand = ValueInput<OVRInput.Controller>("Hand", OVRInput.Controller.All);
            Axis = ValueInput<OVRInput.Axis1D>("Axis", OVRInput.Axis1D.Any);
        }

        private float GetValue(Recursion arg1)
        {
            return OVRInput.Get(Axis.GetValue<OVRInput.Axis1D>(), Hand.GetValue<OVRInput.Controller>());
        }
    }
}