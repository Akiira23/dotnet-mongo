using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api.Data.Collections
{
    public class Hospital
    {
        public Hospital(string nome, double ocupacao, double latitude, double longitude, int recuperados, int obitos)
        {
            this.Nome = nome;
            this.Ocupacao = ocupacao;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
            this.Recuperados = recuperados;
            this.Obitos = obitos;
        }
        
        public string Nome { get; set; }
        public double Ocupacao { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
        public int Recuperados { get; set; }
        public int Obitos { get; set; }
    }
}