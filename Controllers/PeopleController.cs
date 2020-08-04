using System.Collections.Generic;
using AgendaConsultorioMedico.Data;
using AgendaConsultorioMedico.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace AgendaConsultorioMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _repository;
        private readonly IMapper _mapper;

        public PeopleController(IPeopleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        // GET /api/<PeopleController>
        [HttpGet]
        public ActionResult<IEnumerable<PersonReadDto>> Get()
        {
            var people = _repository.GetAllPeople();
            return Ok(_mapper.Map<IEnumerable<PersonReadDto>>(people));
        }

        // GET /api/<PeopleController>/{id}
        [HttpGet("{id}", Name = "GetPersonById")]
        public ActionResult<PersonReadDto> GetPersonById(int id)
        {
            var person = _repository.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PersonReadDto>(person));
        }

        // POST /api/<PeopleController>
        [HttpPost]
        public ActionResult<PersonReadDto> CreatePerson(PersonCreateDto newPerson)
        {
                var personModel = _mapper.Map<Person>(newPerson);
                _repository.CreatePerson(personModel);

                var personReadDto = _mapper.Map<PersonReadDto>(personModel);

                return Ok(personReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult<PersonReadDto> UpdatePerson(int id, [FromBody] PersonUpdateDto updateDto)
        {
            var modelFromRepo = _repository.GetPersonById(id);

            if (modelFromRepo == null) return NotFound();

            _mapper.Map(updateDto, modelFromRepo);

            _repository.UpdatePerson(modelFromRepo);
       
            return NoContent();
        }

        // DELETE /api/<PeopleController>/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            var personModel = _repository.GetPersonById(id);

            if (personModel == null) return NotFound();

            _repository.DeletePerson(personModel);

            return NoContent();
        }

        // PATCH /api/<PeopleController>/{id}
        [HttpPatch("{id}")]
        public ActionResult PatchPerson(int id, JsonPatchDocument<PersonCreateDto> patchDocument)
        {
            var modelFromRepo = _repository.GetPersonById(id);

            if (modelFromRepo == null) return NotFound();

            var personToPatch = _mapper.Map<PersonCreateDto>(modelFromRepo);

            // Aplica o PATCH e faz as validações da Model
            patchDocument.ApplyTo(personToPatch, ModelState);

            if (!TryValidateModel(personToPatch)) return ValidationProblem(ModelState);

            _mapper.Map(personToPatch, modelFromRepo);

            _repository.UpdatePerson(modelFromRepo);

            return NoContent();
        }
    }
}