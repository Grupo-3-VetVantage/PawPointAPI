using PawPoint.Domain.Interfaces;
using PawPoint.Infraestructure.Interfaces;
using PawPoint.Infraestructure.Models;

namespace PawPoint.Domain;

public class ReviewDomain: IReviewDomain
{
    private readonly IReviewInfraestructure _reviewInfraestructure;
    public ReviewDomain(IReviewInfraestructure reviewInfraestructure)
    {
        _reviewInfraestructure = reviewInfraestructure;
    }


    public async Task<Review?> GetReviewById(int id)
    {
        return await _reviewInfraestructure.GetReviewById(id);
    }

    public async Task<List<Review>> GetReviews()
    {
        return await _reviewInfraestructure.GetReviews();
    }

    public async Task<bool> CreateReview(Review review)
    {
        return await _reviewInfraestructure.CreateReview(review);
    }

    public async Task<bool> UpdateReview(int id,Review review)
    {
        return await _reviewInfraestructure.UpdateReview(id,review);
    }

    public async Task<bool> DeleteReview(int id)
    {
        return await _reviewInfraestructure.DeleteReview(id);
    }
}