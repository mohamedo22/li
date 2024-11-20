using Library_DEMO.DTOs.CreditCardFolder;
using Library_DEMO.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_DEMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private protected ICreditCardRepo _creditCardRepo;

        public CreditCardController(ICreditCardRepo creditCardRepo)
        {
            _creditCardRepo = creditCardRepo;
        }
        [HttpPost("Add-Credit-Author")]
        public IActionResult AddCreditAuthor(CreditCardDto creditCardDto)
        {
            _creditCardRepo.AddCreditCardAuthor(creditCardDto);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetCreditCardById(int id)
        {
            var card = _creditCardRepo.GetCreditCardById(id);
            return Ok(card);
        }
        [HttpGet("Get-Credits")]
        public IActionResult GetCreditCards()
        {
            var cards = _creditCardRepo.GetCreditCards();
            return Ok(cards);
        }
        [HttpPut("{id}")]
        public IActionResult PutCreditCard(int id, CreditCardDto creditCard)
        {
            _creditCardRepo.UpdateCreditCard(id, creditCard);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCreditCard(int id)
        {
            _creditCardRepo.DeleteCreditCard(id);
            return Ok();
        }
    }
}
