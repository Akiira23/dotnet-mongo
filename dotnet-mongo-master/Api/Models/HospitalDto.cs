using System;

namespace Api.Models
{
    public class HospitalDto
    {
        public string Nome { get; set; }
        public double Ocupacao { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Recuperados { get; set; }
        public int Obitos { get; set; }
    }
}