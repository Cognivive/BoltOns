using Bolt;
using Ludiq;
using Zenject;
using UnityEngine;

namespace Cognivive.Bolt.Units.Zenject
{
    [UnitTitle("Instantiate And Inject")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    [UnitCategory("Zenject")] // Sets unit category in Fuzzy Finder. Subfolders are matched and created.
    public class InstantiateAndInjectUnit : Unit
    {
        private GameObject _output;

        [DoNotSerialize] [NullMeansSelf] public ValueInput Context;
        [DoNotSerialize] [PortLabelHidden] public ControlInput EnterNode;
        [DoNotSerialize] [PortLabelHidden] public ControlOutput ExitNode;
        [DoNotSerialize] public ValueOutput InjectedObject;
        [DoNotSerialize] public ValueInput Orientation;
        [DoNotSerialize] public ValueInput Position;

        [DoNotSerialize] public ValueInput Prototype;

        protected override void Definition()
        {
            EnterNode = ControlInput("EnterNode", DoInjection);
            ExitNode = ControlOutput("ExitNode");
            Prototype = ValueInput<Object>("Prototype", null);
            Context = ValueInput<Context>("Context", null);
            Position = ValueInput<Vector3>("Position", Vector3.zero);
            Orientation = ValueInput<Quaternion>("Orientation", Quaternion.identity);
            InjectedObject = ValueOutput("InjectedObject", delegate { return _output; });
        }

        private void DoInjection(Flow flow)
        {
            Object prototype = Prototype.GetValue<Object>();
            _output = Context.GetValue<Context>().Container.InstantiatePrefab(prototype,
                Position.GetValue<Vector3>(), Orientation.GetValue<Quaternion>(), null);
            flow.Invoke(ExitNode);
        }
    }
}