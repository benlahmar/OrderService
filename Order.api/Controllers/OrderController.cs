using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Domain.Iterfaces;
using Order.Domain.Models;
namespace Order.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IBaseRepository<Command> _repo;

        public OrderController(IBaseRepository<Command> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult savecmd(Command o)
        {
            Task<Command> ot = _repo.Save(o);
            return Ok(ot);
        }

        [HttpGet("{id}")]
        public IActionResult getByid(int id)
        {
            Command o = _repo.findById(id);
            return Ok(o);
        }

        [HttpGet]
        public IActionResult getall()
        {
            return Ok(_repo.findAll());
                
         }

        public IActionResult addcomp(Composant cmp, int idcmd)
        { 
            
        }
    }
}
