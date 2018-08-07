using Bolt;

namespace Core.Cognivive.Bolt.Events.Items
{
    [UnitTitle("On Touch End")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    public class ObjectUntouchedEvent : VRTK_InteractableObjectEvent
    {
        protected override void SetupListener()
        {
            Component.InteractableObjectUntouched += DoTrigger;
        }

        protected override void RemoveListener()
        {
            Component.InteractableObjectUntouched -= DoTrigger;
        }

        public override string InteractingObjectLabel
        {
            get { return "Touching Hand"; }
        }
    }
}