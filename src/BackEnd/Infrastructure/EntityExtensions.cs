using BackEnd.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Infrastructure
{
    public static class EntityExtensions
    {
        public static ConferenceDTO.SessionResponseDto MapSessionResponse(this Session session) =>
            new ConferenceDTO.SessionResponseDto
            {
                ID = session.ID,
                Title = session.Title,
                StartTime = session.StartTime,
                EndTime = session.EndTime,
                Tags = session.SessionTags?
                              .Select(st => new ConferenceDTO.TagDto
                              {
                                  ID = st.TagID,
                                  Name = st.Tag.Name
                              })
                               .ToList(),
                Speakers = session.SessionSpeakers?
                                  .Select(ss => new ConferenceDTO.SpeakerDto
                                  {
                                      ID = ss.SpeakerId,
                                      Name = ss.Speaker.Name
                                  })
                                   .ToList(),
                TrackId = session.TrackId,
                Track = new ConferenceDTO.TrackDto
                {
                    TrackID = session?.TrackId ?? 0,
                    Name = session.Track?.Name
                },
                ConferenceID = session.ConferenceID,
                Abstract = session.Abstract
            };

        public static ConferenceDTO.SpeakerResponseDto MapSpeakerResponse(this Speaker speaker) =>
            new ConferenceDTO.SpeakerResponseDto
            {
                ID = speaker.ID,
                Name = speaker.Name,
                Bio = speaker.Bio,
                WebSite = speaker.WebSite,
                Sessions = speaker.SessionSpeakers?
                    .Select(ss =>
                        new ConferenceDTO.SessionDto 
                        {
                            ID = ss.SessionId,
                            Title = ss.Session.Title
                        })
                    .ToList()
            };

        public static ConferenceDTO.AttendeeResponseDto MapAttendeeResponse(this Attendee attendee) =>
            new ConferenceDTO.AttendeeResponseDto
            {
                ID = attendee.ID,
                FirstName = attendee.FirstName,
                LastName = attendee.LastName,
                UserName = attendee.UserName,
                Sessions = attendee.Sessions?
                    .Select(s =>
                        new ConferenceDTO.SessionDto
                        {
                            ID = s.ID,
                            Title = s.Title,
                            StartTime = s.StartTime,
                            EndTime = s.EndTime
                        })
                    .ToList(),
                Conferences = attendee.ConferenceAttendees?
                    .Select(ca =>
                        new ConferenceDTO.ConferenceDto
                        {
                            ID = ca.ConferenceID,
                            Name = ca.Conference.Name
                        })
                    .ToList(),
            };
    }
}