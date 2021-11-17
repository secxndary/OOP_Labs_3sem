using System;


namespace OOP_Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Supra", 460);
            Engine engine = new Engine();

            Console.WriteLine(new string('=', 107));
            Reflector.ToFile(car, typeof(int));       /// передаем typeof, потому что внутри есть обращение к GetSomeMethods().
                                                      /// внутренние фукнциии ToFile() выводят информацию и в файл, и на консось
            Console.WriteLine(new string('=', 107));
            Reflector.ToFile(engine, typeof(int));

            Console.WriteLine(new string('=', 107));
            Reflector.InvokeClass(car, "Lab12Method");
        }
    }
}
