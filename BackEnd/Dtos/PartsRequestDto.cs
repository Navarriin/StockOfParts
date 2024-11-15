using StockOfMachineParts.Models;

namespace StockOfMachineParts.Dtos;

public record PartsRequestDto(string PartsName, string MachineName, int Quantity, decimal Price);

public static class PartsRequestMapper
{
    public static Parts ToDto(PartsRequestDto requestDto) =>
        requestDto is null
            ? null
            : new Parts(
                    requestDto.PartsName,
                    requestDto.MachineName,
                    requestDto.Quantity,
                    requestDto.Price
                );
}
