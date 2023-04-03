using VtbCase.Shared;

namespace VtbCase.Server.Services.SegmentService
{
    public interface ISegmentService
    {
        Task<List<Segment>> GetSegments();
        Task<Segment?> GetSegmentById(int segmentId);
        Task<Segment> CreateSegment(Segment segment);
        Task<Segment?> UpdateSegment(int segmentId, Segment segment);
        Task<bool> DeleteSegment(int segmentId);
    }
}