using Bolt;
using Ludiq;
using Zenject;

namespace Core.Cognivive.Bolt.Units.Zenject
{
    [UnitTitle("Inject")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    [UnitCategory("Zenject")] // Sets unit category in Fuzzy Finder. Subfolders are matched and created.
    public class InjectUnit : Unit
    {
        private object _output;

        [DoNotSerialize] [NullMeansSelf] public ValueInput Context;
        [DoNotSerialize] [PortLabelHidden] public ControlInput EnterNode;
        [DoNotSerialize] [PortLabelHidden] public ControlOutput ExitNode;
        [DoNotSerialize] public ValueOutput InjectedObject;

        [DoNotSerialize] public ValueInput Object;

        protected override void Definition()
        {
            EnterNode = ControlInput("EnterNode", DoInjection);
            ExitNode = ControlOutput("ExitNode");
            Object = ValueInput<object>("Object");
            Context = ValueInput<Context>("Context");
            InjectedObject = ValueOutput("InjectedObject", delegate { return _output; });
        }

        private void DoInjection(Flow flow)
        {
            _output = Object.GetValue<object>();
            Context.GetValue<Context>().Container.Inject(_output);
            flow.Invoke(ExitNode);
        }
        
    }
}