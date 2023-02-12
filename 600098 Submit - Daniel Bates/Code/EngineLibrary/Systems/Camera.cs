using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace EngineLibrary
{
    struct CameraInitials
    {
        public Vector3 InitialPosition;
        public Vector3 InitialDirection;
    }
    class Camera
    {
        private CameraInitials initials = new CameraInitials();
        public Matrix4 view, projection;
        public Vector3 cameraPosition, cameraDirection, cameraUp;
        private Vector3 targetPosition;
        public float radius = 1.0f;

        public Camera()
        {
            cameraPosition = new Vector3(0.0f, 0.0f, 0.0f);
            initials.InitialPosition = new Vector3(0.0f, 0.0f, 0.0f);

            cameraDirection = new Vector3(0.0f, 0.0f, -1.0f);
            initials.InitialDirection = new Vector3(0.0f, 0.0f, -1.0f);

            cameraUp = new Vector3(0.0f, 1.0f, 0.0f);

            UpdateView();

            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45), 1.0f, 0.1f, 100f);
        }

        public Camera(Vector3 cameraPos, Vector3 targetPos, float ratio, float near, float far)
        {
            cameraUp = new Vector3(0.0f, 1.0f, 0.0f);

            cameraPosition = cameraPos;
            initials.InitialPosition = cameraPos;

            cameraDirection = targetPos - cameraPos;
            cameraDirection.Normalize();
            initials.InitialDirection = cameraDirection;

            UpdateView();

            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45), ratio, near, far);
        }

        public void MoveForward(float move)
        {
            cameraPosition += move*cameraDirection;
            UpdateView();
        }

        public void Translate(Vector3 move)
        {
            cameraPosition += move;
            UpdateView();
        }


        public void RotateY(float angle)
        {
            cameraDirection = Matrix3.CreateRotationY(angle) * cameraDirection;
            UpdateView();
        }

        public void UpdateView()
        {
            targetPosition = cameraPosition + cameraDirection;
            view = Matrix4.LookAt(cameraPosition, targetPosition, cameraUp);
        }
        public void InitialState()
        {
            cameraPosition = initials.InitialPosition;
            cameraDirection = initials.InitialDirection;
            UpdateView();
        }
    }
}
