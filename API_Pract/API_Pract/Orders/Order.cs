namespace API_Pract.Orders 
{ 

    public class Order
    {
        public int id {  get; set; }
        public DateTime Date { get; set; }
        public string client { get; set; } = string.Empty;
        public string services { get; set; } = string.Empty;
        public int sum { get; set; } 
    }
}
