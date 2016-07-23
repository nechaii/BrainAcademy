namespace AirpplaneApp
{
    using System;
    using AirplaneLibrary;
    using System.Reflection;
    using utf8 = System.Text.UTF8Encoding;

    class Program2
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 45);
            Console.OutputEncoding = Console.OutputEncoding = utf8.UTF8;

            Type myType = null;
            UniversalAirplane myUniversalAirplane = new UniversalAirplane();

            /*три способа получения ссылки на магический Type*/
            //1 - myType = typeof(UniversalAirplane);
            //2 - myType = Type.GetType("AirplaneLibrary.UniversalAirplane"); 

            //фича  фреймворка >= 4,5
            //TypeInfo myTypeInfo = myType.GetTypeInfo();
            
            //3 - вызов на экземпляре
            myType = myUniversalAirplane.GetType();

            PrintInfo(myType);
            PrintMethods(myType);
            PrintFields(myType);
            PrintProperties(myType);
            PrintInterfaces(myType);
            PrintCtor(myType);
            PrintAttributes(myType);

            Console.WriteLine(new string('-', 30));
            Console.ReadKey();
        }

        public static void PrintInfo(Type objType)
        {
            Console.WriteLine(new string('-', 30) + "Детали класа");
            Console.WriteLine("Имя:                 {0}", objType.FullName);
            Console.WriteLine("Базовый клас:        {0}", objType.BaseType);
            Console.WriteLine("Абстрактный:         {0}", objType.IsAbstract);
            Console.WriteLine("Ком обьект:          {0}", objType.IsCOMObject);
            Console.WriteLine("Запечатан:           {0}", objType.IsSealed);
            Console.WriteLine("Класс6               {0}", objType.IsClass);
        }

        public static void PrintMethods(Type objType)
        {
            Console.WriteLine(new string('-',30) + "Методы");
            MethodInfo[] methodList = objType.GetMethods();
            /*
             MethodInfo[] methodList = objType.GetMethods(BindingFlags.Instance
                    | BindingFlags.Static
                    | BindingFlags.Public
                    | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
             */

            foreach (MethodInfo p in methodList)
            {
                Console.WriteLine("Method: {0}", p.Name);
            }
        }

        public static void PrintFields(Type objType)
        {
            Console.WriteLine(new string('-', 30) + "Поля");
            FieldInfo[] fieldList = objType.GetFields(BindingFlags.Instance
                    | BindingFlags.Static
                    | BindingFlags.Public
                    | BindingFlags.NonPublic);

            foreach (FieldInfo p in fieldList)
            {
                Console.WriteLine("Method: {0}", p.Name);
            }
        }

        public static void PrintProperties(Type objType)
        {
            Console.WriteLine(new string('-', 30) + "Свойства");
            PropertyInfo[] propList = objType.GetProperties();
            foreach (PropertyInfo p in propList)
            {
                Console.WriteLine("Method: {0}", p.Name);
            }
        }

        public static void PrintInterfaces(Type objType)
        {
            Console.WriteLine(new string('-', 30) + "Интерфейсы");
            Type[] interfaceList = objType.GetInterfaces();
            foreach (Type p in interfaceList)
            {
                Console.WriteLine("Method: {0}", p.Name);
            }
        }

        public static void PrintCtor(Type objType)
        {
            Console.WriteLine(new string('-', 30) + "Конструкторы");
            ConstructorInfo[] ctorList = objType.GetConstructors();
            foreach (ConstructorInfo p in ctorList)
            {
                Console.WriteLine("Method: {0}", p.Name);
            }
        }

        public static void PrintAttributes(Type objType)
        {
            Console.WriteLine(new string('-', 30) + "Атрибуты");
            dynamic[] attributes = objType.GetCustomAttributes(false); //без поверки BaseClasses

            if (attributes.GetLength(0) != 0)
            {
                foreach (dynamic p in attributes)
                {
                    if (p is AirplaneTypeAttribute)
                    {

                        Console.WriteLine(((AirplaneTypeAttribute)p).Vercion + " " + ((AirplaneTypeAttribute)p).Type);
                    }
                }
            }

        }
    }
}
