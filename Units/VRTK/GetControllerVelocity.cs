using Bolt;
using Ludiq;
using VRTK;
using UnityEngine;

namespace Cognivive.Bolt.Units.VRTK
{
    [TypeIcon(typeof(VRTK_SDKManager))] // Choose the type icon. @32x - headers; @16x -ports and fuzzy finder categories. Located in Editor Default Resources.
    [UnitTitle("Controller Velocity")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    [UnitCategory("VRTK")] // Sets unit category in Fuzzy Finder. Subfolders are matched and created.
    public class GetControllerVelocity: Unit
    {
        [DoNotSerialize] public ValueOutput Velocity;
        [DoNotSerialize] public ValueInput Controller;

        protected override void Definition()
        {
            Controller = ValueInput<VRTK_ControllerReference>("Controller Reference");
            Velocity = ValueOutput<Vector3>("Left Hand Controller", GetValue);
        }

        private Vector3 GetValue(Recursion arg1)
        {
            return VRTK_DeviceFinder.GetControllerVelocity(Controller.GetValue<VRTK_ControllerReference>());
        }
    }
}