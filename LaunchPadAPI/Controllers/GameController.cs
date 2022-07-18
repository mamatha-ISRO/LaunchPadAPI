using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaunchPadAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly DataContext context;
        public GameController(DataContext context)
        {
            this.context = context;
        }

        [HttpPost("start-game")]
        public async Task<ActionResult<Game>> CreateGame()
        {
            var game = new Game()
            {
                PlayerOId = Guid.NewGuid(),
                PlayerXId = Guid.NewGuid(),
                Status = GameStatus.STARTED.ToString(),
            };
            this.context.Add(game);
            await this.context.SaveChangesAsync();

            return Ok(game);
        }

        [Route("register-move/{gameId}/{playerId}/{move}")]
        [HttpPut]
        public async Task<IActionResult> RegisterMove(int gameId, Guid playerId, int move)
        {
            if (string.IsNullOrEmpty(playerId.ToString()))
                return BadRequest("PlayerId cannot be empty.");

            if (gameId == 0)
                return BadRequest("Game Id cannot be 0.");

            var game = await this.context.Games.FindAsync(gameId);

            if (game==null)
                return BadRequest("Game Id does not exists.");

            if (!CheckMove.CheckValidMove(move, game.PlayerXMoves, game.PlayerOMoves))
                return BadRequest("Invalid move. This is already taken!");

            game.Status = GameStatus.IN_PROGRESS.ToString();

            if (game.PlayerXId == playerId)
            {
                game.PlayerXMoves += move + "|";
                if (CheckMove.IsWinningMove(game.PlayerXMoves))
                {
                    game.Status = GameStatus.COMPLETED.ToString();
                    game.Result = "PlayerX Wins";
                    await this.context.SaveChangesAsync();
                    return Ok("PlayerX has Won");
                }
            }
                
            if (game.PlayerOId == playerId)
            {
                game.PlayerOMoves += move + "|";
                if (CheckMove.IsWinningMove(game.PlayerOMoves))
                {
                    game.Status = GameStatus.COMPLETED.ToString();
                    game.Result = "PlayerO Wins";
                    await this.context.SaveChangesAsync();
                    return Ok("PlayerO has Won");
                }
            }

            if (CheckMove.IsDraw(game.PlayerXMoves, game.PlayerOMoves))
            {
                game.Status = GameStatus.COMPLETED.ToString();
                game.Result = "Draw";
                await this.context.SaveChangesAsync();
                return Ok("Draw");
            }

            await this.context.SaveChangesAsync();

            return Ok("Move registered successfully");
        }


        [HttpGet("current-running-games")]
        public async Task<ActionResult<List<Game>>> GetCurrentGames()
        {
            var games = await this.context.Games.ToListAsync();

            return Ok(games.FindAll(g => g.Status != "COMPLETED"));
        }

    }
}
