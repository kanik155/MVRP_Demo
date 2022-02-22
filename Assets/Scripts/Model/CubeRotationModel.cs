using UnityEngine;

namespace MVRP.Model
{
    public class CubeRotationModel : MonoBehaviour
    {
        public static CubeRotationModel Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void SetRotationX(float x)
        {
            var rot = Quaternion.AngleAxis(x, Vector3.right);
            transform.rotation = rot;
        }

        public void SetRotationY(float y)
        {
            var rot = Quaternion.AngleAxis(y, Vector3.up);
            transform.rotation = rot;
        }

        public void SetRotationZ(float z)
        {
            var rot = Quaternion.AngleAxis(z, Vector3.forward);
            transform.rotation = rot;
        }
    }
}