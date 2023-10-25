using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace UsersNotebook.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public required string Imie { get; set; }

        [Required, MaxLength(150)]
        public required string Nazwisko { get; set; }

        [Required]
        public DateTime DataUrodzenia { get; set; }

        [Required]
        public string Plec { get; set; }

        public string DodatkoweParametry { get; set; }

        [NotMapped]
        public List<AdditionalParameters> DodatkoweParametryList
        {
            get
            {
                return string.IsNullOrEmpty(DodatkoweParametry) ? new List<AdditionalParameters>() :
                JsonSerializer.Deserialize<List<AdditionalParameters>>(DodatkoweParametry);
            }

            set => DodatkoweParametry = JsonSerializer.Serialize(value);
        }
    }

    public class AdditionalParameters
    {
        public required string Key { get; set; }
        public required string Value { get; set; }
    }
}
