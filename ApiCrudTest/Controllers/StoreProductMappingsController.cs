using ApiCrudTest.Models.DbModels;
using ApiCrudTest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreProductMappingsController : ControllerBase
    {
        private readonly IStoreProductMappingRepository _storeProductMappingRepository;

        public StoreProductMappingsController(IStoreProductMappingRepository storeProductMappingRepository)
        {
            _storeProductMappingRepository = storeProductMappingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreProductMapping>>> GetMappings()
        {
            try
            {
                var mappings = await _storeProductMappingRepository.GetAllMappingsAsync();
                return Ok(mappings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoreProductMapping>> GetMapping(int id)
        {
            try
            {
                var mapping = await _storeProductMappingRepository.GetMappingByIdAsync(id);
                if (mapping == null)
                {
                    return NotFound("Mapping not found");
                }
                return Ok(mapping);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostMapping(StoreProductMapping mapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _storeProductMappingRepository.AddMappingAsync(mapping);
                return CreatedAtAction(nameof(GetMapping), new { id = mapping.MappingID }, mapping);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMapping(int id, StoreProductMapping mapping)
        {
            if (id != mapping.MappingID)
            {
                return BadRequest("Mapping ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _storeProductMappingRepository.UpdateMappingAsync(mapping);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMapping(int id)
        {
            try
            {
                await _storeProductMappingRepository.DeleteMappingAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
