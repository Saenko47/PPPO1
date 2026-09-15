using PaterniLab1.Task1;
using PaterniLab1.Task1.Data;
using PaterniLab1.Task1.Interfaces;
using PaterniLab1.Task1.Model;
using PaterniLab1.Task1.Realization;
using PaterniLab1.Task1.Tools;

namespace PaterniLab1
{
    internal class Program
    {
        public static void Task1()
        {
            var dbContext = new AppDBContextTask1();

            dbContext.Database.EnsureCreated();

            var parseTemplate = new BaseParseTemplate<Person>(
         new GetPathByDialog(),
         new Reader(),
         new PersonParser(new PersonDeserializator()),
         new PersonValidator(),
         new PersonRepository(dbContext),
         new PersonReportGeneretor()
     );
            Console.WriteLine("Lets start");
            parseTemplate.ParseFromFile();
        }
        [STAThread]
        static void Main(string[] args)
        {
            Task1();
        }
    }
}
