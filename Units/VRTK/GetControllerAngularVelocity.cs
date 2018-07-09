using Bolt;
using Ludiq;
using VRTK;
using UnityEngine;

namespace Cognivive.Bolt.Units.VRTK
{
    [TypeIcon(typeof(VRTK_SDKManager))] // Choose the type icon. @32x - headers; @16x -ports and fuzzy finder categories. Located in Editor Default Resources.
    [UnitTitle("Controller Angular Velocity")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    [UnitCategory("VRTK")] // Sets unit category in Fuzzy Finder. Subfolders are matched and created.
    public class GetControllerAngularVelocity : Unit
    {
        [DoNotSerialize] public ValueInput Controller;
        [DoNotSerialize] public ValueOutput Velocity;

        protected override void Definition()
        {
            Controller = ValueInput<VRTK_ControllerReference>("Controller Reference");
            Velocity = ValueOutput("Angular Velocity", GetValue);
        }

        private Vector3 GetValue(Recursion arg1)
        {
            return VRTK_DeviceFinder.GetControllerAngularVelocity(Controller.GetValue<VRTK_ControllerReference>());
        }
    }
}