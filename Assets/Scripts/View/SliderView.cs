using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MVRP.View
{
    public class SliderView : MonoBehaviour
    {
        [SerializeField] private Slider _sliderX, _sliderY, _sliderZ;
        [SerializeField] private Text _textX, _textY, _textZ;

        public IReadOnlyReactiveProperty<float> SliderValueRP_X => _floatReactivePropertyX;
        private readonly FloatReactiveProperty _floatReactivePropertyX = new FloatReactiveProperty();

        public IReadOnlyReactiveProperty<float> SliderValueRP_Y => _floatReactivePropertyY;
        private readonly FloatReactiveProperty _floatReactivePropertyY = new FloatReactiveProperty();

        public IReadOnlyReactiveProperty<float> SliderValueRP_Z => _floatReactivePropertyZ;
        private readonly FloatReactiveProperty _floatReactivePropertyZ = new FloatReactiveProperty();

        private void Start()
        {
            _sliderX.OnValueChangedAsObservable()
                .DistinctUntilChanged()
                .Subscribe(value => { OnValueChange(value, _floatReactivePropertyX, _textX); })
                .AddTo(this);

            _sliderY.OnValueChangedAsObservable()
                .DistinctUntilChanged()
                .Subscribe(value => { OnValueChange(value, _floatReactivePropertyY, _textY); })
                .AddTo(this);

            _sliderZ.OnValueChangedAsObservable()
                .DistinctUntilChanged()
                .Subscribe(value => { OnValueChange(value, _floatReactivePropertyZ, _textZ); })
                .AddTo(this);
        }

        private void OnValueChange(float value, FloatReactiveProperty floatReactiveProperty, Text valueText)
        {
            var arrangeValue = Mathf.Floor((value - 0.5f) * 100) / 100 * 360;
            floatReactiveProperty.Value = arrangeValue;
            valueText.text = arrangeValue.ToString();
        }
    }
}
