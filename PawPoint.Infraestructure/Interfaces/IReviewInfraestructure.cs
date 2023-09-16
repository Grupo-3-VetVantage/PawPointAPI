using PawPoint.Infraestructure.Models;

namespace PawPoint.Infraestructure.Interfaces;

public interface IReviewInfraestructure
{
    Task<Review?> GetReviewById(int id);
    Task<List<Review>> GetReviews();
    Task<bool> CreateReview(Review review);
    Task<bool> UpdateReview(int id,Review review);
    Task<bool> DeleteReview(int id);
    
    
}