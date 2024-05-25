using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Application.DataTransferObjects;
public class ProductDto
{
    public ProductDto(string name, decimal price, int stock, string description, Guid? id)
    {
        Name = name;
        Price = price;
        Stock = stock;
        Description = description;
        Id = id;
    }
    public ProductDto() { }
    public Guid? Id { get; set; }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? Description { get; set; }
}
