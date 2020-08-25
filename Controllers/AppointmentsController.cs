using System.Collections.Generic;
using AgendaConsultorioMedico.Data;
using AgendaConsultorioMedico.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using AgendaConsultorioMedico.Business;

namespace AgendaConsultorioMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsRepository _repository;
        private readonly IMapper _mapper;
        private readonly IAppointmentValidation _appointmentValidation;
        private readonly IPeopleRepository _peopleRepository;

        public AppointmentsController(IAppointmentsRepository repository, IMapper mapper, IAppointmentValidation appointmentValidation, IPeopleRepository peopleRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _appointmentValidation = appointmentValidation;
            _peopleRepository = peopleRepository;
        }

        // GET /api/<AppointmentsController>
        [HttpGet]
        public ActionResult<IEnumerable<AppointmentReadDto>> Get()
        {
            var appointments = _repository.GetAllAppointments();
            return Ok(_mapper.Map<IEnumerable<AppointmentReadDto>>(appointments));
        }

        // GET /api/<AppointmentsController>/{id}
        [HttpGet("{id}", Name = "GetAppointmentById")]
        public ActionResult<AppointmentReadDto> GetAppointmentById(int id)
        {
            var Appointment = _repository.GetAppointmentById(id);
            if (Appointment == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AppointmentReadDto>(Appointment));
        }

        // POST /api/<AppointmentsController>
        [HttpPost]
        public ActionResult<AppointmentReadDto> CreateAppointment(AppointmentCreateDto newAppointment)
        {
                var AppointmentModel = _mapper.Map<Appointment>(newAppointment);
                if (!TryValidateModel(AppointmentModel)) return ValidationProblem(ModelState);

                if (!CanAddAppointment(AppointmentModel))
                {
                    return ValidationProblem("A data de agendamento solicitada não pôde ser encaixada! Por favor agende para outro horário");
                } 
                
                var Person = _peopleRepository.GetPersonById(newAppointment.PersonId);
                if (Person == null) {
                    return NotFound();
                }
                _repository.CreateAppointment(AppointmentModel);

                var AppointmentReadDto = _mapper.Map<AppointmentReadDto>(AppointmentModel);

                return CreatedAtRoute(nameof(GetAppointmentById), new { Id = AppointmentModel.Id }, AppointmentReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult<AppointmentReadDto> UpdateAppointment(int id, [FromBody] AppointmentUpdateDto updateDto)
        {
            var modelFromRepo = _repository.GetAppointmentById(id);

            if (modelFromRepo == null) return NotFound();

            _mapper.Map(updateDto, modelFromRepo);

            _repository.UpdateAppointment(modelFromRepo);
       
            return NoContent();
        }

        // DELETE /api/<AppointmentsController>/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteAppointment(int id)
        {
            var AppointmentModel = _repository.GetAppointmentById(id);

            if (AppointmentModel == null) return NotFound();

            _repository.DeleteAppointment(AppointmentModel);

            return NoContent();
        }

        // PATCH /api/<AppointmentsController>/{id}
        [HttpPatch("{id}")]
        public ActionResult PatchAppointment(int id, JsonPatchDocument<AppointmentCreateDto> patchDocument)
        {
            var modelFromRepo = _repository.GetAppointmentById(id);

            if (modelFromRepo == null) return NotFound();

            var AppointmentToPatch = _mapper.Map<AppointmentCreateDto>(modelFromRepo);

            // Aplica o PATCH e faz as validações da Model
            patchDocument.ApplyTo(AppointmentToPatch, ModelState);

            if (!TryValidateModel(AppointmentToPatch)) return ValidationProblem(ModelState);

            _mapper.Map(AppointmentToPatch, modelFromRepo);

            _repository.UpdateAppointment(modelFromRepo);

            return NoContent();
        }

        private bool CanAddAppointment(Appointment newAppointment)
        {
            var allAppointments = (List<Appointment>) _repository.GetAllAppointments();
            return _appointmentValidation.CanAddAppointment(newAppointment, allAppointments);
        }
    }
}