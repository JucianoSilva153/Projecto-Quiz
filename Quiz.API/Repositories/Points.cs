using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Entities.Points;

namespace Quiz.API.Repositories;

public class PointsService
{
    private readonly IPoint _pointRepository;

    public PointsService(IPoint pointRepository)
    {
        _pointRepository = pointRepository;
    }

    public async Task<bool> RegisterPoints(PointDto pointDto)
    {
        var point = new Point
        {
            Id = pointDto.Id,
            UserId = pointDto.UserId,
            Value = pointDto.PointValue,
            QuizId = pointDto.QuizId
        };

        return await _pointRepository.CreateAsync(point);
    }

    public async Task<IEnumerable<PointDto>> GetAllPontuations()
    {
        return await _pointRepository.GetAllAsync();
    }

    public async Task<PointDto?> GetPontuationById(Guid pointId)
    {
        return await _pointRepository.GetByIdAsync(pointId);
    }
}