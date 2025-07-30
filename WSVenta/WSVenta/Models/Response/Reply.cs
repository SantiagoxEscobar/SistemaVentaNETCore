namespace WSVenta.Models.Response
{
    public class Reply
    {
        public int Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public Reply()
        {
            this.Success = 0;
            this.Message = string.Empty;
            this.Data = new object();
        }
    }
}

