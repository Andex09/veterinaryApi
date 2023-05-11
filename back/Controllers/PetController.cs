using AutoMapper;
using back.DTO;
using back.Models;
using back.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IMapper _mapper; 
        private readonly IPetRepository _petRepository;

        public PetController(IMapper mapper, IPetRepository petRepository) { 
        
            _mapper = mapper;
            _petRepository = petRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var petList = await _petRepository.GetPetList();
                var petListDTO = _mapper.Map<IEnumerable<PetDTO>>(petList);
                return Ok(petList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pet = await _petRepository.GetPet(id);
                if (pet == null)
                {
                    return NotFound();
                }

                var petDTO = _mapper.Map<PetDTO>(pet);
                return Ok(petDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pet = await _petRepository.GetPet(id);
                if (pet == null)
                {
                    return NotFound();
                }
                _petRepository.DeletePet(pet);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PetDTO petDto)
        {
            try
            {
                var pet = _mapper.Map<Pet>(petDto);

                pet.CreationDate = DateTime.Now;
                pet.Id = 0;
                pet = await _petRepository.AddPet(pet);

                var petItemDto = _mapper.Map<PetDTO>(pet);
                return CreatedAtAction("Get", new { id = pet.Id }, petItemDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PetDTO petDto)
        {
            try
            {
                var pet = _mapper.Map<Pet>(petDto);
                if (id != pet.Id)
                {
                    return BadRequest();
                }

                var petItem = await _petRepository.GetPet(id);
                if (petItem == null)
                {
                    return NotFound();
                }

                await _petRepository.UpdatePet(pet);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
