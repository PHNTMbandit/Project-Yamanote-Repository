using UnityEngine;

namespace ProjectYamanote.UI
{
    public class FreezeTextRotation : MonoBehaviour
    {
        private Quaternion iniRot;

        private void Start()
        {
            iniRot = transform.rotation;
        }

        private void LateUpdate()
        {
            transform.rotation = iniRot;
        }
    }
}