using System.Configuration;
using System.IO;
using meridian.core;
using meridian.diagram;

namespace meridian.smolensk.codegen
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = GetConnectionString();
            string solutionDirectory = PathUtils.DetectSolutionPath();
            string contextFilePath = Path.Combine(solutionDirectory, @"..\etc\context\smolensk.xml");
            string project = "meridian.smolensk";

            var dg = new MySqlDiagramContext(connectionString);
            dg.GetOperationContext().Load(contextFilePath);
            dg.SyncControllers();
            //dg.SyncAll("changelog");
            //dg.SyncTable("actions_rating");
            //dg.SyncTable("blog_marks");
            //dg.SyncTable("company_rating");
            //dg.SyncTable("places_rating");
            //dg.SyncTable("restaurant_rating");
            dg.SyncTable("photobank_user_albums");
           
            

            var basicGenerator = new MysqlGenerator(dg.GetOperationContext(), dg.GetBackendOperationContext());
            basicGenerator.Namespace = project;
            basicGenerator.ProjectName = project;
            //basicGenerator.Generate();

            Parser parser = new Parser();
            parser.Feeder = new ConsoleFeeder();
            parser.Executor = new SimpleExecutor(dg);
            parser.Generator = basicGenerator;
            parser.Launch();

            dg.GetOperationContext().Save(contextFilePath);
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }
    }
}
