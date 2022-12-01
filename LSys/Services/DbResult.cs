namespace LSys.Services
{
    public class DbResult<T> where T: class
    {
        public int Result { get; set; }
        public T DTOEntity { get; set; }
    }
}
