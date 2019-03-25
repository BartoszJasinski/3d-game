using System;

using Game.Figure;
using Game.Math;
using Math = Game.Math.Math;
using Vector = Game.Math.Vector;


namespace Game.Camera
{
    public class Camera
    {
    
        public Vector cameraPosition { get; set; }
        public Vector cameraFront { get; set; }
        public Vector upAxis { get; set; }
        public Matrix viewMatrix { get; set; }
        public double cameraSpeed { get; set; }
        
        //TODO: maybe delete this constructor (it is not used)
//        public Camera() : this(new Vector(0, 0, 0), new Vector(0, 0, 0), new Vector(0, 0, -1), 1)
//        {
//            
//        }
        
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
        
        //TODO: probably bug in this function (when camera passes (0, 0, 0) camera )
        public Matrix LookAt(Vector cameraPosition, Vector cameraTarget, Vector upAxis)
        {
//            Vector direction = (cameraPosition - cameraTarget).Normalize(2);
//            direction.Normalize(2);
//            Vector<double> up = upAxis.Normalize(2);
            
//            Vector left = direction.CrossProduct(upAxis).Normalize(2);
//            Vector up = left.CrossProduct(direction);
            
//            Matrix<double> ViewMatrix = DenseMatrix.OfArray(new double[,] {
//                {right[0], right[1], right[2], 0},
//                {upAxis[0], upAxis[1], upAxis[2], 0},
//                {cameraTarget[0], cameraTarget[1], cameraTarget[2], 0},
//                {0, 0, 0, 1}}) * 
//                DenseMatrix.OfArray(new double[,] {
//                {1, 0, 0, - cameraPosition[0]},
//                {0, 1, 0, - cameraPosition[1]},
//                {0, 0, 1, - cameraPosition[2]},
//                {0, 0, 0, 1}});

//            Matrix<double> ViewMatrix = DenseMatrix.OfArray(new double[,]
//            {
////                -left[0] * cameraPosition[0] - left[1] * cameraPosition[1] - left[2] * cameraPosition[2]
//                {left[0], left[1], left[2], cameraPosition.DotProduct(left)},
//                {up[0], up[1], up[2], up.DotProduct(cameraPosition)},
//                {-direction[0], -direction[1], -direction[2], direction.DotProduct(cameraPosition)},
//                {0, 0, 0, 1}
//            });


            //TODO: refactor (maybe delete all CastVectorTo3D() (vectors should have as many coordinates as initialized in constructor))
            Vector upVector = (upAxis.CastVectorTo3D()).Normalize(2);
            Vector zAxis = ((cameraPosition - cameraTarget).CastVectorTo3D()).Normalize(2);
            Vector xAxis = ((upVector.CrossProduct(zAxis)).CastVectorTo3D()).Normalize(2);
            Vector yAxis = ((zAxis.CrossProduct(xAxis)).CastVectorTo3D()).Normalize(2);
            
            Matrix ViewMatrix = new Matrix(new double[,]
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