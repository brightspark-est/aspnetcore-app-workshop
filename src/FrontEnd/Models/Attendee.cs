using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ConferenceDTO;

namespace FrontEnd.Models
{
    public class Attendee
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string UserName { get; set; }

        [DisplayName("First name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }

        [DisplayName("Email address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public ConferenceDTO.Attendee AsDto()
        {
            return new ConferenceDTO.Attendee
            {
                ID = ID,
                UserName = UserName,
                FirstName = FirstName,
                LastName = LastName,
                EmailAddress = EmailAddress
            };
        }
    }
}