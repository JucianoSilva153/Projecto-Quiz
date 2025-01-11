using Quiz.Domain.Common.DTOs;

namespace Quiz.UI.Helpers;

public class CarouselSlide
{
    public List<KwizDto> Items { get; set; } = new();
}

public static class CarouselHelper
{
    public static List<CarouselSlide> GroupKwizDtosForCarousel(IEnumerable<KwizDto> kwizDtos, int itemsPerSlide = 3)
    {
        return kwizDtos
            .Select((kwiz, index) => new { kwiz, index })
            .GroupBy(x => x.index / itemsPerSlide)
            .Select(group => new CarouselSlide
            {
                Items = group.Select(x => x.kwiz).ToList()
            })
            .ToList();
    }
    
    public static List<CarouselSlide> GetRecentKwizzes(IEnumerable<KwizDto> kwizDtos, int itemsPerSlide = 3)
    {
        var recentKwizzes = kwizDtos
            .OrderByDescending(k => k.CreatedAt);
        return GroupKwizDtosForCarousel(recentKwizzes, itemsPerSlide);
    }
    
    public static List<CarouselSlide> GetTrendingKwizzes(IEnumerable<KwizDto> kwizDtos, int itemsPerSlide = 3)
    {
        var trendingKwizzes = kwizDtos
            .OrderByDescending(k => k.TimesPlayed)
            .Take(10); // Pegamos os 10 mais populares
        return GroupKwizDtosForCarousel(trendingKwizzes, itemsPerSlide);
    }
    
    public static List<CarouselSlide> GetFeaturedKwizzes(IEnumerable<KwizDto> kwizDtos, int itemsPerSlide = 3)
    {
        // Simula "em destaque" selecionando 10 quizzes aleatórios
        var random = new Random();
        var featuredKwizzes = kwizDtos
            .OrderBy(_ => random.Next())
            .Take(10); // Pegamos 10 aleatórios
        return GroupKwizDtosForCarousel(featuredKwizzes, itemsPerSlide);
    }
    
    
}
