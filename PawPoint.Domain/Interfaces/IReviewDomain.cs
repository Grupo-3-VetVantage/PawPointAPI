using PawPoint.Infraestructure.Models;

namespace PawPoint.Domain.Interfaces;

public interface IReviewDomain
{
    Task<Review?> GetReviewById(int id);
    Task<List<Review>> GetReviews();
    Task<bool> CreateReview(Review review);
    Task<bool> UpdateReview(int id,Review review);
    Task<bool> DeleteReview(int id);
    
}