using LojaVirtual.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Application.DataTransferObjects;
public class CartDto
{
    public CartDto (Guid userId, Guid? id)
    {
        UserId = userId;
        Id = id;
    }
    public CartDto() { }
    public Guid? Id { get; set; }
    public Guid UserId { get; set; }
    public List<CartProduct>? Products { get; set; }
}