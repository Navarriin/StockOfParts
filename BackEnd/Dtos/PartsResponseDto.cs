using StockOfMachineParts.Models;

namespace StockOfMachineParts.Dtos;

public record PartsResponseDto(int Id, string PartsName, string MachineName, int Quantity, decimal Price);

public record MachineResponseDto(int Id, string ModelName);

public static class PartsResponseMapper
{
    public static PartsResponseDto MapToPartsResponseDto(Parts parts) =>
        parts is null 
            ? null 
            : new PartsResponseDto(
                parts.Id,
                parts.PartsName,
                parts.MachineName,
                parts.Quantity,
                parts.Price
            );
}