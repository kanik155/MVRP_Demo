using MVRP.Model;
using MVRP.View;
using UniRx;
using UnityEngine;

namespace MVRP.Presenter
{
    public class CubeRotationPresenter : MonoBehaviour
    {
        [SerializeField] private SliderView _sliderView;

        private void Start()
        {
            var cubeRotationLogic = CubeRotationModel.Instance;

            _sliderView.SliderValueRP_X.Subscribe(value => { cubeRotationLogic.SetRotationX(value); }).AddTo(this);

            _sliderView.SliderValueRP_Y.Subscribe(value => { cubeRotationLogic.SetRotationY(value); }).AddTo(this);

            _sliderView.SliderValueRP_Z.Subscribe(value => { cubeRotationLogic.SetRotationZ(value); }).AddTo(this);
        }
    }
}
