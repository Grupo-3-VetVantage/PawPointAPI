using Microsoft.EntityFrameworkCore;
using PawPoint.Infraestructure.Context;
using PawPoint.Infraestructure.Interfaces;
using PawPoint.Infraestructure.Models;

namespace PawPoint.Infraestructure;

public class ReviewInfraestructure:IReviewInfraestructure
{
    private readonly VetDbContext _VetDBContext;
    public ReviewInfraestructure(VetDbContext context)
    {
        _VetDBContext = context;
    }
    
    public async Task<Review?> GetReviewById(int id)
    {
        return await _VetDBContext.Reviews.FirstOrDefaultAsync(review => review.Id == id);
    }

    public async Task<List<Review>> GetReviews()
    {
        return await _VetDBContext.Reviews.ToListAsync();
    }

    public async Task<bool> CreateReview(Review review)
    {
        try
        {
            review.IsActive = true;
            _VetDBContext.Reviews.Add(review);
            await _VetDBContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception) { throw new Exception(exception.Message); }
    }

    public async Task<bool> UpdateReview(int id,Review review)
    {
        try
        {
            var reviewFound =  _VetDBContext.Reviews.Find(id);
            reviewFound!.DateUpdated = DateTime.Now;
            reviewFound.Rating = review.Rating;
            reviewFound.Description = review.Description;
            _VetDBContext.Reviews.Update(reviewFound);
            await _VetDBContext.SaveChangesAsync();
            return true;

        }
        catch (Exception e)
        {throw new Exception(e.Message);}
    }

    public async Task<bool> DeleteReview(int id)
    {
        var reviewFound = _VetDBContext.Reviews.Find(id);
        reviewFound!.IsActive = false;
        _VetDBContext.Reviews.Update(reviewFound);
        await _VetDBContext.SaveChangesAsync();
        return true;
    }
}