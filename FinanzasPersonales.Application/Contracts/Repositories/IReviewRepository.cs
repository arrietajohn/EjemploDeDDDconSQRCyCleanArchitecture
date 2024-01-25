using FinanzasPersonales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Application.Contracts.Repositories
{
    internal interface IReviewRepository
    {
        Task<bool> SaveAsync(Review review);
        Task<bool> UpdateAsync(Review review);
        Task<bool> DeleteAsync(Review review);
        Task<bool> DeleteAsync(int reviewId);
        Task<IEnumerable<Review>> GetAllAsync();
        Task<IEnumerable<Review>> GetByDateAsync(DateTime date);
        Task<IEnumerable<Review>> GetByActionAsync(string actiion);
        Task<IEnumerable<Review>> GetByReviewerAsync(int reviewerId);
        Task<IEnumerable<Review>> GetByReviewerAsync(Reviewer reviewer);
        Task<IEnumerable<Review>> GetByReviewerUserAsync(int userId);
        Task<IEnumerable<Review>> GetByReviewerUserAsync(User user);
        Task<IEnumerable<Review>> GetByReviewedUserAsync(int userId);
        Task<IEnumerable<Review>> GetByReviewedUserAsync(User user);

        Task<Review> GetByid(int id);

    }
}
}
