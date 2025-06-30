namespace T2.Models
{
    public class Borrow
    {
        public int sid { get; set; }
        public int Bid { get; set; }

        public Borrow(int si, int Bi)
        {
            sid = si;
            Bid = Bi;
        }
        public Borrow() { }
    }
}