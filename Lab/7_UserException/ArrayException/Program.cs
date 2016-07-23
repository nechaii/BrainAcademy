using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayException
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {                
                DisplayMenu.PrintHeaderMenuText();
                Presenter myPresenter = new Presenter();

                string choiceIs = Console.ReadLine();

                DisplayMenu.PrintSeparator();
                DisplayMenu.ClearSector();

                switch (choiceIs)
                {                    
                    case "1":
                        {
                            try
                            {
                                var myArray = myPresenter.GetFakeArray();
                                if (myArray == null)
                                    throw new NullReferenceException("Error get array: ", new NullReferenceException());
                            }
                            catch (NullReferenceException ex)
                            {                                
                                Console.WriteLine(ex.Message + "\n\tInnerException: " + ex.InnerException.Message);
                            }
                        }
                        break;

                    case "2":
                        {
                            try
                            {
                                try
                                {
                                    myPresenter.CreateFakeIntArray();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Сюда не зайдем");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("И сюбда тоже не зайдем");
                            }

                        }
                        break;

                    case "3":
                        {
                            try
                            {
                                try
                                {
                                    myPresenter.GetFakeElementOfArray();
                                }
                                catch (IndexOutOfRangeException ex)
                                {
                                    throw new IndexOutOfRangeException("Error get elemen of array", new IndexOutOfRangeException());
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message + "\n\tInnerException: " + ex.InnerException.Message + "\n" +ex.StackTrace);
                            }

                        }
                        break;

                    case "4":
                        {
                            try
                            {
                                try
                                {
                                    throw new UserExceptionA("UserExceptionA");
                                }
                                catch (UserExceptionB ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (UserExceptionA ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                        }
                        break;

                    default:
                        {
                            break;
                        }
                }
            }
        }
    }
}
