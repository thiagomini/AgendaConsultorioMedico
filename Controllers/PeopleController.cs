using System.Collections.Generic;
using AgendaConsultorioMedico.Data;
using AgendaConsultorioMedico.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public ActionResult<IEnumerable<PersonReadDto>> Get()
        {
            var people = _repository.GetAllPeople();
            return Ok(_mapper.Map<IEnumerable<PersonReadDto>>(people));
        }

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
    }
}