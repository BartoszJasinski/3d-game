using MathNet.Numerics.LinearAlgebra;

namespace Game.Misc
{
    public static class VectorExtensions
    {
        public static Vector<double> DropLastValue(this Vector<double> vector)
        {
            Vector<double> resultVec = vector;
            return resultVec;
        }
    }
    
    
//    public static class MyExtensions
//    {
//        public static int WordCount(this String str)
//        {
//            return str.Split(new char[] { ' ', '.', '?' }, 
//                StringSplitOptions.RemoveEmptyEntries).Length;
//        }
//    }   
}