using UnityEngine;

namespace Rift
{
    public class FaceCamera : MonoBehaviour
    {
        private void LateUpdate()
        {
            var camera = Camera.main;
            transform.LookAt(transform.position + camera.transform.rotation * Vector3.back, camera.transform.rotation * Vector3.up);
        }
    }
}
