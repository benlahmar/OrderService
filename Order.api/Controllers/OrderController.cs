using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order.api.RemoteCall;
using Order.Domain.Iterfaces;
using Order.Domain.Models;
namespace Order.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IBaseRepository<Command> _repo;
        public readonly IBaseRepository<Composant> _repocomp;
        private readonly IHttpProduit _http;

        public OrderController(IBaseRepository<Command> repo, 
            IBaseRepository<Composant> repocomp,
            IHttpProduit http)
        {
            _repo = repo;
            _repocomp = repocomp;
            _http = http;
        }

        [HttpPost]
        public IActionResult savecmd([FromBody] Command o)
        {
            Command ot = _repo.add(o);
            ot.Status = Status.Created;
            return Ok(ot);
        }

        [HttpGet("{id}")]
        public IActionResult getByid(int id)
        {
            Command o = _repo.FindByCondition(x => x.Id == id)
                .Include(c => c.composants).First();
            
            if (o == null)
                return NoContent();
            else

            return Ok(o);
        }

        [HttpGet]
        public IActionResult getall()
        {
            return Ok(_repo.findAll());
                
         }

        [HttpPost("{idcmd}/composants")]
        public IActionResult addcomp([FromBody] Composant cmp, int idcmd)
        {
            Command c = _repo.findById(idcmd);
            cmp.command = c;
            //verification de stock
            //cmp.quantite  vs qte en stock  httpclient
            //si qte n est pas disp  Canceled

            Composant cm = _repocomp.add(cmp);
            return Ok(cm);
        }

        [HttpGet("{idcmd}/composants")]
        public IActionResult getallcomp(int idcmd)
        {
            List<Composant> cmps = _repocomp.FindByCondition(c => c.command.Id == idcmd).ToList();

            cmps.ForEach(c => c.Produit = _http.getById(c.idproduit));
            return Ok(cmps);    
     

        }

        [HttpGet("now")]
        public DateTime gettime()
        {
            return DateTime.Now;

        }

        [HttpGet("retry/{id}")]
        public Task<ActionResult<Produit>> getprdretry(int id)
        {
            return _http.GetById2(id);
        }
    }
}
