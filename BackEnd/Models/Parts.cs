using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StockOfMachineParts.Models;

public class Parts
{
    [Key]
    [DisplayName("Id")]
    public int Id { get; init; }
    
    [DisplayName("Nome da Peça")]
    [Required(ErrorMessage = "Campo Obrigatorio")]
    [StringLength(70, ErrorMessage = "O nome deve conter 70 caracteres")]
    [MinLength(4, ErrorMessage = "O nome deve conter no minimo 4 caracteres")]
    public string PartsName { get; private set; }
    
    [DisplayName("Nome da Maquina")]
    [Required(ErrorMessage = "Campo Obrigatorio")]
    [StringLength(70, ErrorMessage = "O nome deve conter 70 caracteres")]
    [MinLength(4, ErrorMessage = "O nome deve conter no minimo 4 caracteres")]
    public string MachineName { get; private set; }
    
    [DisplayName("Quantidade")]
    [Required(ErrorMessage = "Campo Obrigatorio")]
    [Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser maior ou igual a 0")]
    public int Quantity { get; private set; }
    
    [DisplayName("Valor")]
    [Required(ErrorMessage = "Campo Obrigatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
    public decimal Price { get; private set; }
    
    public Parts(){}
    
    public Parts(string partsName, string machineName, int quantity, decimal price)
    {
        PartsName = partsName;
        MachineName = machineName;
        Quantity = quantity;
        Price = price;
    }

    public void SetPartsName(string partsName)
    {
        PartsName = partsName;
    }
    
    public void SetMachineName(string machineName)
    {
        MachineName = machineName;
    }

    public void SetQuantity(int quantity)
    {
        Quantity = quantity;
    }

    public void SetPrice(decimal price)
    {
        Price = price;
    }
}