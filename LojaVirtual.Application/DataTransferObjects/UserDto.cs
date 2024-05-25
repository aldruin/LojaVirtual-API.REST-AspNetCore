using LojaVirtual.Domain.Entities;

namespace LojaVirtual.Application.DataTransferObjects;
public class UserDto
{
    public UserDto(Guid userId, string email, string name, string cpf)
    {
        Id = userId;
        Email = email;
        Name = name;
        CPF = cpf;
    }
    public UserDto() { }

    public Guid? Id {get; set;}
    public string? Name {get; set;}
    public string? CPF { get; set; }
    public string? Email {get; set;}
    public string? Password {get; set;}
    public Guid? CartId { get; set; }
}