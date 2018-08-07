using Bolt;

namespace Core.Cognivive.Bolt.Events.Items
{
    [UnitTitle("On Touch Begin")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    public class ObjectTouchedEvent : VRTK_InteractableObjectEvent
    {
        protected override void SetupListener()
        {
            Component.InteractableObjectTouched += DoTrigger;
        }

        protected override void RemoveListener()
        {
            Component.InteractableObjectTouched -= DoTrigger;
        }

        public override string InteractingObjectLabel
        {
            get { return "Touching Hand"; }
        }
    }
}