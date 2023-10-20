﻿namespace UserNotebook.Core.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string Plec { get; set; }
        public List<AdditionalParametersDto> DodatkoweParametry { get; set; } = new List<AdditionalParametersDto>();
    }

    public class AdditionalParametersDto
    {
        public required string Key { get; set; }
        public required string Value { get; set; }
    }
}
