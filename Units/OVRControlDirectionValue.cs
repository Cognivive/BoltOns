using Bolt;
using Ludiq;
using UnityEngine;

namespace Core.Cognivive.Bolt.Units
{
    [TypeIcon(typeof(OVRControlDirectionValue))] // Choose the type icon. @32x - headers; @16x -ports and fuzzy finder categories. Located in Editor Default Resources.
    [UnitTitle("Get Thumbstick Direction")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    [UnitCategory("OVR")] // Sets unit category in Fuzzy Finder. Subfolders are matched and created.
    public class OVRControlDirectionValue : Unit
    {
        [DoNotSerialize] public ValueInput Hand;

        [DoNotSerialize] public ValueInput Thumbstick;

        [DoNotSerialize] public ValueOutput Value;

        protected override void Definition()
        {
            Value = ValueOutput<Vector2>("Value", GetValue);
            Hand = ValueInput<OVRInput.Controller>("Hand", OVRInput.Controller.All);
            Thumbstick = ValueInput<OVRInput.Axis2D>("Thumbstick", OVRInput.Axis2D.Any);
        }

        private Vector2 GetValue(Recursion arg1)
        {
            return OVRInput.Get(Thumbstick.GetValue<OVRInput.Axis2D>(), Hand.GetValue<OVRInput.Controller>());
        }
    }
}