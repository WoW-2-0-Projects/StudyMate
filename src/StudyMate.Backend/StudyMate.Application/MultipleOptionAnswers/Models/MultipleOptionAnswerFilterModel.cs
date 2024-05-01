using StudyMate.Domain.Common.Queries;

namespace StudyMate.Application.MultipleOptionAnswers.Models;

public class MultipleOptionAnswerFilterModel:FilterPagination
{
    /// <summary>
    /// Computes the hash code for the filter.
    /// </summary>
    /// <returns>The hash code for the filter.</returns>
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageSize);
        hashCode.Add(PageToken);

        return hashCode.ToHashCode();
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current filter.
    /// </summary>
    /// <param name="obj">The object to compare with the current filter.</param>
    /// <returns>True if the specified object is equal to the current filter; otherwise, false.</returns>
    public override bool Equals(object? obj) => 
        obj is MultipleOptionAnswerFilterModel clientFilter 
        && clientFilter.GetHashCode() == GetHashCode();
}