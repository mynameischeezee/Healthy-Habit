namespace HealthyHabit.Models
{
    public class Color : ModelTemplate
    {
        public string HexCode { get; set; }
        public string ColorName { get; set; }
        public Color()
        {

        }
        public Color(string Hex, string Name)
        {
            this.HexCode = Hex;
            this.ColorName = Name;
        }
    }
}
