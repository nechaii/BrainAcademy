
namespace ClassLibrary1
{
    public class Class1
    {
        public void MyReverse<T>(ref T[] array)
        {
            T[] tmpArray = new T[array.Length];
            for (int i = 0, j= array.Length-1; i < tmpArray.Length; i++, j--)
            {
                tmpArray[i] = array[j];
            }
            array = tmpArray; 
        }

    }
}
