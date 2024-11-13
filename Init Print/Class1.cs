using System;

namespace Init_Print
{
    public class Class1
    {
        public static void Init(int[] A)
        {
            Random r = new Random();
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = r.Next(-20, 20);
            }
        }
        public static void Print(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write("{0,4}", A[i]);
            }
            Console.WriteLine("\n\n");
        }
    }
}
