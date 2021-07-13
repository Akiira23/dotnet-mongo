using System;
using Api.Data.Collections;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HospitalController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Hospital> _hospitalCollection;

        public HospitalController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _hospitalCollection = _mongoDB.DB.GetCollection<Hospital>(typeof(Hospital).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarHospital([FromBody] HospitalDto dto)
        {
            var hospital = new Hospital(dto.Nome, dto.Ocupacao, dto.Latitude, dto.Longitude, dto.Recuperados, dto.Obitos);

            _hospitalCollection.InsertOne(hospital);
            
            return StatusCode(201, "Hospital adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterHospital()
        {
            var hospital = _hospitalCollection.Find(Builders<Hospital>.Filter.Empty).ToList();
            
            return Ok(hospital);
        }

        [HttpPut]
        public ActionResult AtualizarRecuperados([FromBody] HospitalDto dto)
        {
            var hospital = new Hospital(dto.Nome, dto.Ocupacao, dto.Latitude, dto.Longitude, dto.Recuperados, dto.Obitos);
            _hospitalCollection.UpdateOne(Builders<Hospital>.Filter.Where(_ => _.Nome == dto.Nome), Builders<Hospital>.Update.Set("recuperados", dto.Recuperados));
            return Ok();
        }

        [HttpPut]
        public ActionResult AtualizarObitos([FromBody] HospitalDto dto)
        {
            var hospital = new Hospital(dto.Nome, dto.Ocupacao, dto.Latitude, dto.Longitude, dto.Recuperados, dto.Obitos);
            _hospitalCollection.UpdateOne(Builders<Hospital>.Filter.Where(_ => _.Nome == dto.Nome), Builders<Hospital>.Update.Set("obitos", dto.Obitos));
            return Ok();
        }

        [HttpDelete("{Nome}")]
        public ActionResult Delete(string nome_hospital)
        {
            _hospitalCollection.DeleteOne(Builders<Hospital>.Filter.Where(_ => _.Nome == nome_hospital));
            return Ok();
        }
    }
}
