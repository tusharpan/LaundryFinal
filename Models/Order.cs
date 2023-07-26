namespace LaundryFinal.Models
{
    public class Order
    {
        public int Order_Id { get; set; }
        public int User_Id { get; set; }

        public int Shirts { get; set; }
        public int Pants { get; set; }
        public int Suits { get; set; }

        public decimal Amount { get; set; }

        public String Del_Address { get; set; }

        public Order() { }
        public Order(int User_id, int Shirts, int Pants, int Suits, decimal Amount, String Del_address,int Order_id)
        {
            this.Order_Id = Order_id;
            this.User_Id = User_id;
            this.Suits = Suits;
            this.Shirts = Shirts;
            this.Pants = Pants;
            this.Amount = Amount;
            this.Del_Address = Del_address;
        }


    }
}