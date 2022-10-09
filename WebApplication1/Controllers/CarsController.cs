using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly DataContext _context;

        public CarsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
                return BadRequest("Car not found.");

            return Ok(car);
        }
        [HttpGet]
        public async Task<ActionResult<List<Car>>> Get()
        {
            

            return Ok(await _context.Cars.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Car>>> AddCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return Ok(await _context.Cars.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Car>>> UpdateCar(Car request)
        {
            var dbCar = await _context.Cars.FindAsync(request.Id);
            if (dbCar == null)
                return BadRequest("Car not found.");

            dbCar.colour = request.colour;
            dbCar.make = request.make;
            dbCar.model = request.model;
            dbCar.year = request.year;

            await _context.SaveChangesAsync();
            
            return Ok(await _context.Cars.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Car>>> DeleteCar(int id)
        {
            var dbCar = await _context.Cars.FindAsync(id);
            if (dbCar == null)
                return BadRequest("Car not found.");

            _context.Cars.Remove(dbCar);
            await _context.SaveChangesAsync();

            return Ok(await _context.Cars.ToListAsync());
        }


    }
}
