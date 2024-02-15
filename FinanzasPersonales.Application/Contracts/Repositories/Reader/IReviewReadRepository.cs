using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Reader;

public interface IReviewReadRepository<T> : IBaseDomainModelReadRepository<T> where T : Review
{


    Task<IEnumerable<Review>> GetByDateAsync(DateTime date);
    Task<IEnumerable<Review>> GetByActionAsync(string actiion);
    Task<IEnumerable<Review>> GetByReviewerAsync(int reviewerId);
    Task<IEnumerable<Review>> GetByReviewerAsync(Reviewer reviewer);
    Task<IEnumerable<Review>> GetByReviewerUserAsync(int userId);
    Task<IEnumerable<Review>> GetByReviewerUserAsync(User user);
    Task<IEnumerable<Review>> GetByReviewedUserAsync(int userId);
    Task<IEnumerable<Review>> GetByReviewedUserAsync(User user);

}

