namespace VueNET.Cli
{
    public class Property
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public bool IsForSorting { get; set; }

        public string GetDeclaration()
        {
            return "public " + Type + " " + Name + " { get; set; }";
        }
    }
}
