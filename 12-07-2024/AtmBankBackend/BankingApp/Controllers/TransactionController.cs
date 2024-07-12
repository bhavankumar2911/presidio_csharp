using BankingApp.Exceptions;
using BankingApp.Models;
using BankingApp.Models.DTO;
using BankingApp.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {


        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }


        [HttpPost("Withdraw")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> WithdrawMoney(WithdrawDTO dto)
        {
            try
            {

                var result = await _transactionService.Withdraw(dto);
                return Ok(result);
            }
            catch (UnauthorizedUserException uue)
            {

                return Unauthorized(new ErrorModel(401, uue.Message));
            }
            catch(InsufficientFundsException ife)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorModel(500, ife.Message));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorModel(500, ex.Message)); 
            }

        }

        [HttpPost("Deposit")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> DepositMoney(DepositDTO depositDto)
        {
            try
            {
                var result = await _transactionService.Deposit(depositDto);
                return Ok(result);
            }
            catch (InvalidCardException e)
            {
                return NotFound(new ErrorModel(400, e.Message));
            }
            catch(UnauthorizedUserException e)
            {
                return Unauthorized(new ErrorModel(401, e.Message));
            }
            catch(LimitExceededException e)
            {
                return NotFound(new ErrorModel(404, e.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }

        }


        [HttpPost("Transactions")]
        [ProducesResponseType(typeof(List<TransactionReturnDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<TransactionReturnDTO>>> GetAllTransactions(CardReaderDTO cardReadDto)
        {
            try
            {
                var result = await _transactionService.GetAllTransactions(cardReadDto);
                return Ok(result);
            }
            catch (InvalidCardException e)
            {
                return NotFound(new ErrorModel(400, e.Message));
            }
            catch (UnauthorizedUserException e)
            {
                return Unauthorized(new ErrorModel(401, e.Message));
            }
            catch (EmptyListException e)
            {
                return NotFound(new ErrorModel(400, e.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }

        }

        [HttpPost("GetBalance")]
        [ProducesResponseType(typeof(BalanceReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BalanceReturnDTO>> GetBalance(CardReaderDTO cardReadDto)
        {
            try
            {
                var result = await _transactionService.GetBalance(cardReadDto);
                return Ok(result);
            }
            catch (InvalidCardException e)
            {
                return NotFound(new ErrorModel(400, e.Message));
            }
            catch (UnauthorizedUserException e)
            {
                return Unauthorized(new ErrorModel(401, e.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }

        }

    }
}
