using System;

namespace ArrayException
{
    class Presenter
    {
        public string[] GetFakeArray()
        {
            return null ;
        }

        public void CreateFakeIntArray()
        {
            try
            {
                int[] tstArray = null;
                string[] array = Model.GetStringArray();
                tstArray = new int[array.Length];

                for (int i = 0; i < array.Length; i++)
                {
                    tstArray[i] = int.Parse(array[i]);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string GetFakeElementOfArray(int j = 5)
        {
            return Model.GetStringArray()[j];
        }

    }
}
