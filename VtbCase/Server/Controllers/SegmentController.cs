using VtbCase.Server.Services.SegmentService;
using VtbCase.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VtbCase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentController : ControllerBase
    {
        private readonly SegmentService _segmentService;

        public SegmentController(SegmentService segmentService)
        {
            _segmentService = segmentService;
        }

        [HttpGet]
        public async Task<List<Segment>> GetSegments()
        {
           return await _segmentService.GetSegments();
        }

        [HttpGet("{id}")]
        public async Task<Segment?> GetSegmentById(int id)
        {
            return await _segmentService.GetSegmentById(id);
        }

        [HttpPost]
        public async Task<Segment?> CreateSegment(Segment segment)
        {
            return await _segmentService.CreateSegment(segment);
        }

        [HttpPut("{id}")]
        public async Task<Segment?> UpdateSegment(int id, Segment segment)    {
            return await _segmentService.UpdateSegment(id, segment);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteSegment(int id)
        {
            return await _segmentService.DeleteSegment(id);
        }
    }
}