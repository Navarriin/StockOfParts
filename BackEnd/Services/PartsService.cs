using StockOfMachineParts.Dtos;
using StockOfMachineParts.Repositories;

namespace StockOfMachineParts.Services;

public interface IPartsService
{
    Task<List<PartsResponseDto>> GetAllPartsAsync();
    Task<PartsResponseDto> GetAllPartsAsyncById(int id);
    Task<PartsResponseDto> AddParts(PartsRequestDto partsDto);
    Task<PartsResponseDto> UpdateParts(int id, PartsRequestDto partsDto);
    Task DeleteParts(int id);
}

public class PartsService : IPartsService
{
    private readonly IPartsRepository _partsRepository;

    public PartsService(IPartsRepository partsRepository)
    {
        _partsRepository = partsRepository;
    }
    
    public async Task<List<PartsResponseDto>> GetAllPartsAsync()
    {
        var result = await _partsRepository.GetPartsAsync();
        return result.Select((a) => 
            PartsResponseMapper.MapToPartsResponseDto(a))
            .OrderBy(x => x.Id)
            .ToList();
    }

    public async Task<PartsResponseDto> GetAllPartsAsyncById(int id)
    {
        var result = await _partsRepository.GetPartsAsyncById(id);
        return PartsResponseMapper.MapToPartsResponseDto(result);
    }

    public async Task<PartsResponseDto> AddParts(PartsRequestDto partsDto)
    {
        var parts = PartsRequestMapper.ToDto(partsDto);
        var result = await _partsRepository.AddParts(parts);
        return PartsResponseMapper.MapToPartsResponseDto(result);
    }

    public async Task<PartsResponseDto> UpdateParts(int id, PartsRequestDto partsDto)
    {
        var parts = PartsRequestMapper.ToDto(partsDto);
        var result = await _partsRepository.UpdateParts(id, parts);
        return PartsResponseMapper.MapToPartsResponseDto(result);
    }

    public async Task DeleteParts(int id)
    {
        await _partsRepository.DeleteParts(id);
    }
}