using System.Numerics;

namespace matrixhelper
{
    public class Matrix<T> where T : INumber<T>
    {
        public T Dot(IList<T> vector1, IList<T> vector2)
        {
            if(vector1.Count != vector2.Count)
            {
                throw new Exception("Invlaid input to dot product");
            }

            T result = T.Zero;

            for (int i = 0; i < vector1.Count; i++)
            {
                result += vector1[i] * vector2[i];
            }

            return result;
        }
    }
}
