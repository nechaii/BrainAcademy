namespace AirplaneLateBindingApp
{
    using System;
    using System.IO;
    using System.Reflection;
    using utf8 = System.Text.UTF8Encoding;

    class Program2
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 45);
            Console.OutputEncoding = Console.OutputEncoding = utf8.UTF8;

            Assembly myUniversalAirplaneAssembly = null;

            try
            {
                //для избежания ексепшина так как у нас сборка не со строгим в GAC ей не место - то надо закинуть в бин АПП  две билиотеки;
                myUniversalAirplaneAssembly = Assembly.Load("AirplaneLibrary");
                //PrintAboutAssembly(myUniversalAirplaneAssembly);
                CreateInstanceAndCallMethod(myUniversalAirplaneAssembly);
            }

            catch (FileNotFoundException exp)
            {
                Console.WriteLine(exp.Message);
            }

            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            Console.WriteLine(new string('-', 30));
            Console.ReadKey();
        }

        public static void CreateInstanceAndCallMethod(Assembly assembly)
        {
            Type type = assembly.GetType("AirplaneLibrary.UniversalAirplane");

            //object objInstance = Activator.CreateInstance(type);
            dynamic objInstance = Activator.CreateInstance(type);

            MethodInfo objInstanceMethod = null; // type.GetMethod("GetFlightAttendant");
            //objInstanceMethod.Invoke(objInstance, null);

            objInstanceMethod = type.GetMethod("GetFlightAttendant");

            //object[] param = { " - LateBinding" };
            dynamic[] param = { " - LateBinding" };
            objInstanceMethod.Invoke(objInstance, param);
        }

        public static void PrintAboutAssembly(Assembly assembly)
        {            
            Console.WriteLine(new string('-', 30) + "Сборка");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(assembly.FullName);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(new string('-', 30) + "Определенные типы в сборке");
            Type[] types = assembly.GetTypes();
            foreach (Type p in types)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("тип: {0}", p.Name);
                Console.ForegroundColor = ConsoleColor.Gray;
                                
                Console.WriteLine(new string('-', 10) + "Члены типа");
                MemberInfo[] typeMembers = p.GetMembers();

                foreach (MemberInfo m in typeMembers)
                {
                    if (m.MemberType == MemberTypes.Method)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("{0,-5}:  ", m.MemberType);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("{0}", m);

                        MethodInfo methodInfo = m as MethodInfo;
                        ParameterInfo[] methodParameterInfo = methodInfo.GetParameters();
                                               
                        Console.Write(" кол. парам: {0}", methodParameterInfo.Length);

                        if (methodParameterInfo.Length!=0)
                        { foreach (ParameterInfo pi in methodParameterInfo)
                                Console.WriteLine(" имя: {0}, позиц: {1}, тип: {2}", pi.Name, pi.Position, pi.ParameterType);
                        }
                        Console.WriteLine();
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("{0,-15}:  ", m.MemberType);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("{0}", m);
                    }                    
                }
            }
        }


    }
}
