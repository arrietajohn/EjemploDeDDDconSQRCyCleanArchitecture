using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Reader;

public interface IReviewerReadRepository<T> : IBaseDomainModelReadRepository<T> where T : Reviewer
{

    public Task<IEnumerable<Reviewer>> GetByStartDateAsync(DateTime startDate);
    public Task<IEnumerable<Reviewer>> GetByStartDateBetweenAsync(DateTime date1, DateTime date2);
    public Task<IEnumerable<Reviewer>> GetByEndingDateAsync(DateTime date1);
    public Task<IEnumerable<Reviewer>> GetByEndingDateBetweenAsync(DateTime date1, DateTime date2);
    public Task<IEnumerable<Reviewer>> GetByStateAsync(DateTime date1, DateTime date2);

    public Task<IEnumerable<Reviewer>> GetByCanViewEmailAsync(bool IsOrNot);
    public Task<IEnumerable<Reviewer>> GetByCanViewNumberPhoneAsync(bool IsOrNot);
    public Task<IEnumerable<Reviewer>> GetByCanViewAddressAsync(bool IsOrNot);
    public Task<IEnumerable<Reviewer>> GetByCanViewPhotoAsync(bool IsOrNot);
    public Task<IEnumerable<Reviewer>> GetByReviewRequestAsync(int reviewRequestId);
    public Task<IEnumerable<Reviewer>> GetByReviewRequestAsync(ReviewRequest reviewRequest);
    public Task<IEnumerable<Reviewer>> GetByReviewedUserAsync(int userId);
    public Task<IEnumerable<Reviewer>> GetByReviewedUserAsync(User user);
    public Task<IEnumerable<Reviewer>> GetByReviewerUserAsync(User user);
    public Task<IEnumerable<Reviewer>> GetByReviewerUserAsync(int userId);
    public Task<IEnumerable<Reviewer>> GetByRequestingUserAsync(User user);
}
