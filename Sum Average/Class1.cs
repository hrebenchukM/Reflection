namespace Sum_Average
{
    public class Class3
    {
        public static int SumOfElements(int[] A)
        {
            int s = 0;
            for (int i = 0; i < A.Length; i++)
            {
                s += A[i];
            }
            return s;
        }
        public static double Average(int[] A)
        {
            double s = 0;
            for (int i = 0; i < A.Length; i++)
            {
                s += A[i];
            }
            return s / A.Length;
        }
    }
}
