using VtbCase.Shared;

namespace VtbCase.Client.Services.SegmentService
{
    public interface ISegmentService
    {
        List<Segment> Segments { get; set; }

        Task GetSegments();
        Task<Segment?> GetSegmentById(int id);

        Task CreateSegment(Segment segment);

        Task UpdateSegment(int id, Segment segment);    
        Task DeleteSegment(int id); 
    }
}
