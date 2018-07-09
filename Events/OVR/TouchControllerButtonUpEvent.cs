using Bolt;
using Ludiq;

namespace Cognivive.Bolt.Events.OVR
{
    [TypeIcon(typeof(TouchControllerButtonUpEvent))] // Choose the type icon. @32x - headers; @16x -ports and fuzzy finder categories. Located in Editor Default Resources.
    [UnitTitle("On Touch Button Up")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    [UnitCategory("Events/OVR")] // Sets unit category in Fuzzy Finder. Subfolders are matched and created.
    public class TouchControllerButtonUpEvent : GameObjectEventUnit
    {
        [DoNotSerialize] public ValueInput Hand;

        [DoNotSerialize] public ValueInput Button;

        protected override void Definition()
        {
            base.Definition();
            Hand = ValueInput<OVRInput.Controller>("Hand", OVRInput.Controller.All);
            Button = ValueInput<OVRInput.Button>("Button", OVRInput.Button.Any);
        }
        
        public override void Update()
        {
            base.Update();
            if (OVRInput.GetUp(Button.GetValue<OVRInput.Button>(), Hand.GetValue<OVRInput.Controller>()))
            {
                Trigger();
            }
        }
    }
}