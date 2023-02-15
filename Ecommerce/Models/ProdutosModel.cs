using Microsoft.AspNetCore.Http;

namespace Ecommerce.Models
{
    public class Produtos
    {
        public int id { get; set; }
        public string nome_produto { get; set; }
        public string descricao { get; set; }
        public double valor { get; set; }
        public int usuario { get; set; }

        //public IFormFile img_produto { get; set; }
    }
}
