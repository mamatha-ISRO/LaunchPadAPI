namespace LaunchPadAPI
{
    public class Game
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public string? Result { get; set; } // WON, DRAW

        public Guid PlayerXId { get; set; }
        public string? PlayerXMoves { get; set; }

        public Guid PlayerOId { get; set; }
        public string? PlayerOMoves { get; set; }

    }
}
