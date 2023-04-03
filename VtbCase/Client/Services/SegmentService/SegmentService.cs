using VtbCase.Shared;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace VtbCase.Client.Services.SegmentService
{
    public class SegmentService : ISegmentService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

       
        public SegmentService(HttpClient http, NavigationManager navigationManager) {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Segment> Segments { get; set; } = new List<Segment>();
        public async Task CreateSegment(Segment segment)
        {
            await _http.PostAsJsonAsync("api/segment", segment);
            _navigationManager.NavigateTo("segments");
        }

        public async Task DeleteSegment(int id)
        {
            var result = await _http.DeleteAsync($"api/segment/{id}");
            _navigationManager.NavigateTo("segments");
        }

        public async Task<Segment?> GetSegmentById(int id)
        {
            var result = await _http.GetAsync($"api/segment/{id}");
            if (result.StatusCode == HttpStatusCode.OK) {

                return await result.Content.ReadFromJsonAsync<Segment>();
             }
            return null;
        }

        public async Task GetSegments()
        {
            var result = await _http.GetFromJsonAsync<List<Segment>>("api/segments");
            if (result is not null)
                Segments = result;
        }

        public async Task UpdateSegment(int id, Segment segment)
        {
            await _http.PutAsJsonAsync($"api/segment/{id}",segment);
            _navigationManager.NavigateTo("segments");
        }
    }
}
