using Library_DEMO.DTOs.IdentityCardFolder;
using Library_DEMO.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_DEMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityCardController : ControllerBase
    {
        private readonly IIdentityCardRepo _identityCardRepo;

        public IdentityCardController(IIdentityCardRepo identityCardRepo)
        {
            _identityCardRepo = identityCardRepo;
        }

        [HttpPost("Add-Card-Author")]
        public IActionResult AddCardAuthor(IdentityCardDto identityCardDto)
        {
            _identityCardRepo.AddIdentityCardAuthor(identityCardDto);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetIdentityCardById(int id)
        {
            var card = _identityCardRepo.GetIdentityCardById(id);
            return Ok(card);
        }
        [HttpGet("Get-IdentityCards")]
        public IActionResult GetIdentityCards()
        {
            var card = _identityCardRepo.GetAllIdentityCard();
            return Ok(card);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateIdentityCard(int id,  IdentityCardDto identityCardDto)
        {
            _identityCardRepo.UpdateIdentityCardAuthor(id, identityCardDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteIdentityCard(int id)
        {
            _identityCardRepo.RemoveIdentityCard(id);
            return Ok();
        }
    }
}
