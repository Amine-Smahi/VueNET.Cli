namespace VueNET.Cli.ValueObjects
{
    public class Property
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public string GetDeclaration()
        {
            return "public " + Type + " " + Name + " { get; set; }";
        }
    }
}
