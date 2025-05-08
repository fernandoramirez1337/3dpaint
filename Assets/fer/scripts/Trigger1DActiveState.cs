using Oculus.Interaction;
using UnityEngine;

namespace Oculus.Interaction
{
    public class Trigger1DActiveState : MonoBehaviour, IActiveState
    {
        public enum TriggerSource
        {
            Left,
            Right
        }

        public enum ComparisonMode
        {
            GreaterThan,
            LessThan
        }

        [SerializeField]
        private TriggerSource _trigger = TriggerSource.Right;

        [SerializeField]
        private ComparisonMode _comparison = ComparisonMode.GreaterThan;
        public ComparisonMode Comparison
        {
            get => _comparison;
            set => _comparison = value;
        }

        [SerializeField]
        private bool _absoluteValues = false;
        public bool AbsoluteValues
        {
            get => _absoluteValues;
            set => _absoluteValues = value;
        }

        [SerializeField]
        private float _threshold = 0.5f;
        public float Threshold
        {
            get => _threshold;
            set => _threshold = value;
        }

        public bool Active { get; private set; }

        private void Update()
        {
            float value = _trigger == TriggerSource.Right
                ? OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger)
                : OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);

            if (AbsoluteValues)
                value = Mathf.Abs(value);

            Active = (_comparison == ComparisonMode.GreaterThan)
                ? value > _threshold
                : value < _threshold;
        }
    }
}