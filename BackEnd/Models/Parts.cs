using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StockOfMachineParts.Models;

public class Parts
{
    [Key]
    [DisplayName("Id")]
    public int Id { get; init; }
    
    [Required(ErrorMessage = "Campo Obrigatorio")]
    [StringLength(70, ErrorMessage = "O nome deve conter 70 caracteres")]
    [MinLength(4, ErrorMessage = "O nome deve conter no minimo 4 caracteres")]
    [DisplayName("Nome")]
    public string PartsName { get; private set; }
    
    [Required(ErrorMessage = "Campo Obrigatorio")]
    [DisplayName("Quantidade")]
    public int Quantity { get; private set; }
    
    [Required(ErrorMessage = "Campo Obrigatorio")]
    [DisplayName("Valor")]
    public decimal valueUnit { get; private set; }
    
    public int MachineId { get; private set; }
    public Machine Machine { get; init; }
}