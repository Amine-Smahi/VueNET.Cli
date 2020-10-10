namespace VueNET.Cli
{
    public class Property
    {
        public string Modifier { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public bool IsForSorting { get; set; }

        public string GetDeclaration()
        {
            return Modifier + " " + Type + " " + Name + " { get; set; }";
        }
    }
}
