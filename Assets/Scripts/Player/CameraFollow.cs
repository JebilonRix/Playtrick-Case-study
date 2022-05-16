using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace RedPanda.CameraFollow
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private Vector3 _followDistance;
        [SerializeField] private Vector3 _followRotation;

        private void Update() => SetPosition();
        public void SetPosition()
        {
            if (_target != null)
            {
                transform.position = _target.transform.position + _followDistance;
                transform.rotation = Quaternion.Euler(_followRotation);
            }
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(CameraFollow))]
    public class CameraFollowEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            CameraFollow cameraFollow = (CameraFollow)target;

            if (GUILayout.Button("Set Camera Position"))
            {
                cameraFollow.SetPosition();
            }
        }
    }
#endif
}