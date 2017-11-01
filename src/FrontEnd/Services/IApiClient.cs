using ConferenceDTO;
using System.Collections.Generic;
using System.Threading.Tasks;


public interface IApiClient
{
    Task<List<SessionResponseDto>> GetSessionsAsync();
    Task<SessionResponseDto> GetSessionAsync(int id);
    Task<List<SpeakerResponseDto>> GetSpeakersAsync();
    Task<SpeakerResponseDto> GetSpeakerAsync(int id);
    Task PutSessionAsync(SessionDto session);
    Task<List<SearchResultDto>> SearchAsync(string query);
    Task AddAttendeeAsync(AttendeeDto attendee);
    Task<AttendeeResponseDto> GetAttendeeAsync(string name);
    Task DeleteSessionAsync(int id);
    Task<List<SessionResponseDto>> GetSessionsByAttendeeAsync(string name);
    Task AddSessionToAttendeeAsync(string name, int sessionId);
    Task RemoveSessionFromAttendeeAsync(string name, int sessionId);
}