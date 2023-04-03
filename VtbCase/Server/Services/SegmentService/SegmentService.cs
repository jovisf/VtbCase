using VtbCase.Server.Data;
using VtbCase.Shared;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace VtbCase.Server.Services.SegmentService
{
    public class SegmentService : ISegmentService
    {
        private readonly DataContext _context;

        public SegmentService(DataContext context)
        {
            _context = context;
        }

        public async Task<Segment> CreateSegment(Segment segment)
        {
            _context.Add(segment);
            await _context.SaveChangesAsync();
            return segment;
        }

        public async Task<bool> DeleteSegment(int segmentId)
        {
            var dbSegment = await _context.Segments.FindAsync(segmentId);
            if (dbSegment == null)
            {
                return false;
            }

            _context.Remove(dbSegment);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Segment?> GetSegmentById(int segmentId)
        {
            var dbSegment = await _context.Segments.FindAsync(segmentId);
            return dbSegment;
        }

        public async Task<List<Segment>> GetSegments()
        {
            return await _context.Segments.ToListAsync();
        }

        public async Task<Segment?> UpdateSegment(int segmentId, Segment segment)
        {
            var dbSegment = await _context.Segments.FindAsync(segmentId);
            if (dbSegment != null)
            {
                dbSegment.Nome = segment.Nome;
                dbSegment.Descricao = segment.Descricao;

                await _context.SaveChangesAsync();
            }

            return dbSegment;
        }
    }
}