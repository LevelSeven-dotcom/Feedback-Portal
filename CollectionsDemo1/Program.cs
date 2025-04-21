namespace CollectionsDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // store 10 ints

            // static typed collection

            //int[] numbers = new int[10];

            // store n ints

            // store n doubles

            System.Collections.Generic.List<int> ints = new List<int>();

            DynamicArray<int> numbers = new DynamicArray<int>();


            ints.Add(1);


            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);
            numbers.Add(6);
            numbers.Add(7);
            numbers.Add(8);
            numbers.Add(9);
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);
            numbers.Add(6);
            numbers.Add(7);
            numbers.Add(8);
            numbers.Add(9);
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers.Get(i));
            }



        }
    }

    public interface IDynaicIntArray
    {
        void Add(int x);
        int Get(int x);
    }

    public class DynamicArray<T> //: IDynaicIntArray
    {
        private T[] numbers = new T[5];
        private int index = 0;
        public void Add(T x)
        {
            if (index < numbers.Length) // full
            {
                T[] temp = new T[numbers.Length * 2];
                Array.Copy(numbers, temp, numbers.Length);
                numbers = temp;
            }
            numbers[index++] = x;
        }

        public T Get(int x)
        {
            return numbers[x];
        }

        public int Length { get { return index; } }
    }

    public class DynamicDoubleArray
    {
        private double[] numbers = new double[5];
        private int index = 0;
        public void Add(double x)
        {
            if (index < numbers.Length) // full
            {
                double[] temp = new double[numbers.Length * 2];
                Array.Copy(numbers, temp, numbers.Length);
                numbers = temp;
            }
            numbers[index++] = x;
        }

        public double Get(int x)
        {
            return numbers[x];
        }

        public int Length { get { return index; } }
    }

}
