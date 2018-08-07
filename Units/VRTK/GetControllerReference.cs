using Bolt;
using Ludiq;
using VRTK;

namespace Core.Cognivive.Bolt.Units.VRTK
{
    [TypeIcon(typeof(VRTK_SDKManager))] // Choose the type icon. @32x - headers; @16x -ports and fuzzy finder categories. Located in Editor Default Resources.
    [UnitTitle("Controller Reference")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    [UnitCategory("VRTK")] // Sets unit category in Fuzzy Finder. Subfolders are matched and created.
    public class GetControllerReference : Unit
    {
        [DoNotSerialize] public ValueInput Hand;
        [DoNotSerialize] public ValueOutput Reference;

        protected override void Definition()
        {
            Hand = ValueInput("Hand", SDK_BaseController.ControllerHand.None);
            Reference = ValueOutput("Velocity", GetValue);
        }

        private VRTK_ControllerReference GetValue(Recursion arg1)
        {
            return VRTK_ControllerReference.GetControllerReference(Hand.GetValue<SDK_BaseController.ControllerHand>());
        }
    }
}