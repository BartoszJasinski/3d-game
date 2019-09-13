using Game.Math;

namespace Game.Camera
{
    public class Camera
    {
    
        public Vector cameraPosition { get; set; }
        public Vector cameraFront { get; set; }
        public Vector upAxis { get; set; }
        public Matrix viewMatrix { get; set; }
        public double cameraSpeed { get; set; }
        
        public Camera(Vector cameraPosition, Vector cameraFront, Vector upAxis) : this(cameraPosition, cameraFront, upAxis, 1)
        {
            this.cameraPosition = cameraPosition;
            this.cameraFront = cameraFront;
            this.upAxis = upAxis;
        }
        
        public Camera(Vector cameraPosition, Vector cameraFront, Vector upAxis, double cameraSpeed)
        {
            this.cameraPosition = cameraPosition;
            this.cameraFront = cameraFront;
            this.upAxis = upAxis;
            this.cameraSpeed = cameraSpeed;
        }

        public Matrix LookAt()
        {
            return LookAt(cameraPosition, cameraPosition + cameraFront, upAxis);
        }
        
        public Matrix LookAt(Vector cameraPosition, Vector cameraTarget, Vector upAxis)
        {
            Vector upVector = (upAxis.CastVectorTo3D()).Normalize();
            Vector zAxis = ((cameraPosition.CastVectorTo3D() - cameraTarget.CastVectorTo3D()).CastVectorTo3D()).Normalize();
            Vector xAxis = ((upVector.CrossProduct(zAxis)).CastVectorTo3D()).Normalize();
            Vector yAxis = ((zAxis.CrossProduct(xAxis)).CastVectorTo3D()).Normalize();
            
            Matrix ViewMatrix = new Matrix(new[,]
            {
                {xAxis.x, yAxis.x, zAxis.x, cameraPosition.x},
                {xAxis.y, yAxis.y, zAxis.y, cameraPosition.y},
                {xAxis.z, yAxis.z, zAxis.z, cameraPosition.z},
                {0, 0, 0, 1}
            });

            ViewMatrix = ViewMatrix.Inverse();
            
            return ViewMatrix;

        }
    }
}