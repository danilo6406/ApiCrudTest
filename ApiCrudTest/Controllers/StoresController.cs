using ApiCrudTest.Models.DbModels;
using ApiCrudTest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;

        public StoresController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Store>>> GetStores()
        {
            try
            {
                var stores = await _storeRepository.GetAllStoresAsync();
                return Ok(stores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> GetStore(int id)
        {
            try
            {
                var store = await _storeRepository.GetStoreByIdAsync(id);
                if (store == null)
                {
                    return NotFound("Store not found");
                }
                return Ok(store);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostStore(Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _storeRepository.AddStoreAsync(store);
                return CreatedAtAction(nameof(GetStore), new { id = store.StoreID }, store);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStore(int id, Store store)
        {
            if (id != store.StoreID)
            {
                return BadRequest("Store ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _storeRepository.UpdateStoreAsync(store);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            try
            {
                await _storeRepository.DeleteStoreAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
