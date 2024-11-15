using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StockOfMachineParts.Models;

public class Machine
{
    [Key]
    [DisplayName("Id")]
    public int Id { get; init; }
    
    [Required(ErrorMessage = "Campo Obrigatorio")]
    [StringLength(70, ErrorMessage = "O nome do modelo deve conter 70 caracteres")]
    [MinLength(4, ErrorMessage = "O nome do modelo deve conter no minimo 4 caracteres")]
    [DisplayName("Nome do Modelo")]
    public string MachineModel { get; private set; }
    
    public ICollection<Parts> Parts { get; private set; }

    public Machine(string machineModel)
    {
        MachineModel = machineModel;
    }
}