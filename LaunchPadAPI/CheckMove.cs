namespace LaunchPadAPI
{
    public class CheckMove
    {
        public static bool CheckValidMove(int currentMove, string playerXMoves, string playerOMoves)
        {
            var existingMoves = playerXMoves + "|" + playerOMoves;

            var moves = existingMoves.Split('|', StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();

            return !moves.Any(i => i == currentMove);
        }

        public static bool IsWinningMove(string playerMoves)
        {
            var moves = playerMoves.Split('|', StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();

            List<List<int>> successLists = new List<List<int>>();
            successLists.Add(new List<int> { 1, 2, 3 });
            successLists.Add(new List<int> { 4, 5, 6 });
            successLists.Add(new List<int> { 7, 8, 9 });
                       
            successLists.Add(new List<int> { 1, 4, 7 });
            successLists.Add(new List<int> { 2, 5, 8 });
            successLists.Add(new List<int> { 3, 6, 9 });
                       
            successLists.Add(new List<int> { 1, 5, 9 });
            successLists.Add(new List<int> { 3, 5, 7 });

            foreach (List<int> successList in successLists)
            {
                bool hasAll = successList.All(itm2 => moves.Contains(itm2));
                if (hasAll)
                    return true;
            }

            return false;
        }

        public static bool IsDraw(string playerXMoves, string playerOMoves)
        {
            var exhaustedMoves = playerXMoves + "|" + playerOMoves;

            var moves = exhaustedMoves.Split('|', StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();

            var allPos = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            bool hasAll = allPos.All(itm2 => moves.Contains(itm2));

            return hasAll;
        }
    }
}
