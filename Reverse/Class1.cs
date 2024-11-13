namespace Reverse
{
    public class Class2
    {
        public static void Reverse(int[] A)
        {
            for (int i = 0; i < A.Length / 2; i++)
            {
                int temp = A[i];
                A[i] = A[A.Length - 1 - i];
                A[A.Length - 1 - i] = temp;
            }
        }
        public static void Neighbor(int[] A)
        {
            for (int i = 0; i < A.Length; i += 2)
            {
                int temp = A[i];
                A[i] = A[i + 1];
                A[i + 1] = temp;
            }
        }
    }
}
