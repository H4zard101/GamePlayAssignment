using UnityEngine;

namespace Attempt_2.camera
{
    public class CameraArcFollow : MonoBehaviour
    {
        // Start is called before the first frame update
        public float CameraMoveSpeed = 120f;
        public GameObject CameraFollowObj;
        private Vector3 followPos;
        public Vector2 ClampMinMax;

        public float inputSensitivity = 150f;
        
        private Vector3 Velocity = Vector3.zero;
        public GameObject CameraObj;
        public GameObject PlayerObj;

        private float camDistanceXToPlayer;
        private float camDistanceYToPlayer;
        private float camDistanceZToPlayer;

        private float mouseX;
        private float mouseY;
        private float finalInputX;
        private float finalInputZ;

        private float rotX = 0f;
        private float rotY = 0f;

        private Quaternion rotateTo;
        private Quaternion rotateFrom;

        public float smoothness;
        void Start()
        {
            Vector3 rot = transform.localRotation.eulerAngles;
            rotX = rot.x;
            rotY = rot.y;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            float inputX = Input.GetAxis("RightStickHorizontal");
            float inputZ = Input.GetAxis("RightStickVertical");
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");

            finalInputX = inputX + mouseX;
            finalInputZ = inputZ + mouseY;
            rotY += finalInputX * inputSensitivity * Time.deltaTime;
            rotX += finalInputZ * inputSensitivity * Time.deltaTime;
           
            rotateFrom = transform.rotation;
            
            rotX = Mathf.Clamp(rotX, ClampMinMax.x, ClampMinMax.y);
            Quaternion rotateTo = Quaternion.Euler(rotX, rotY, 0f);
            
            transform.rotation = Quaternion.Lerp (rotateFrom, rotateTo, Time.deltaTime * smoothness);

            // Quaternion rotateTo = Quaternion.Euler(rotX, rotY, 0f);
            // transform.rotation = rotateTo;
        }

        private void FixedUpdate()
        {
            CameraUpdater();
        }

        void CameraUpdater()
        {
            Transform target = CameraFollowObj.transform;
            float step = CameraMoveSpeed * Time.deltaTime;
            
            Vector3 desiredPosition = target.position;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref Velocity, step);
            transform.position = smoothedPosition;
        }

    }
}
