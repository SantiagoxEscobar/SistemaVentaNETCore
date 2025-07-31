namespace WS_SistemaVenta.Models.Response
{
    public class Reply
    {
        public int success { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public Reply()
        {
            this.success = 0;
        }
    }
}
