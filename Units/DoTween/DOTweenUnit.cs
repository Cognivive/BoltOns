using Bolt;
using DG.Tweening;
using Ludiq;

namespace Cognivive.Bolt.Units.DoTween
{
    public abstract class DOTweenUnit : Unit
    {
        [DoNotSerialize] [NullMeansSelf] public ValueInput Context;
        [DoNotSerialize] public ValueInput Duration;

        [DoNotSerialize] public ValueInput Easing;
        [DoNotSerialize] [PortLabelHidden] public ControlOutput ImmediateExecute;
        [DoNotSerialize] public ControlOutput OnComplete;
        [DoNotSerialize] public ControlOutput OnUpdate;
        [DoNotSerialize] [PortLabelHidden] public ControlInput TriggerNode;
        

        protected override void Definition()
        {
            TriggerNode = ControlInput("TriggerNode", StartTween);
            ImmediateExecute = ControlOutput("ImmediateExecute");
            OnComplete = ControlOutput("OnComplete");
            OnUpdate = ControlOutput("OnUpdate");
            Easing = ValueInput<Ease>("Easing", Ease.Linear);
            Duration = ValueInput<float>("Duration", 0f);

            Relation(TriggerNode, ImmediateExecute);
            Relation(TriggerNode, OnComplete);
            Relation(TriggerNode, OnUpdate);
        }

        private void StartTween(Flow flow)
        {
             GetTween().OnComplete(DoComplete).OnUpdate(DoUpdate).SetEase(Easing.GetValue<Ease>());
            flow.Invoke(ImmediateExecute);
        }

        private void DoComplete()
        {
            Flow.New().Invoke(OnComplete);
        }

        private void DoUpdate()
        {
            Flow.New().Invoke(OnUpdate);
        }

        protected abstract Tweener GetTween();
    }
}