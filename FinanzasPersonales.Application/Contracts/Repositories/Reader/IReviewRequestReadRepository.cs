using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Reader;

public interface IReviewRequestReadRepository<T> : IBaseDomainModelReadRepository<T> where T : ReviewRequest
{
    public Task<IEnumerable<ReviewRequest>> GetBySubjectAsync(string subject);
    public Task<IEnumerable<ReviewRequest>> GetByStartDateAsync(DateTime startDate);
    public Task<IEnumerable<ReviewRequest>> GetByStartDateBetweenAsync(DateTime date1, DateTime date2);
    public Task<IEnumerable<ReviewRequest>> GetByEndingDateAsync(DateTime date1);
    public Task<IEnumerable<ReviewRequest>> GetByEndingDateBetweenAsync(DateTime date1, DateTime date2);
    public Task<IEnumerable<ReviewRequest>> GetByReasonAsync(string raason);
    public Task<IEnumerable<ReviewRequest>> GetByRequestedUserAsync(int userId);
    public Task<IEnumerable<ReviewRequest>> GetByRequestedUserAsync(User user);
    public Task<IEnumerable<ReviewRequest>> GetByRequestingUserAsync(int userId);
    public Task<IEnumerable<ReviewRequest>> GetByRequestingUserAsync(User user);
    public Task<ReviewRequest> GetByReviewerAsync(int reviewerId);
    public Task<ReviewRequest> GetByReviewerAsync(Reviewer reviewer);


}
