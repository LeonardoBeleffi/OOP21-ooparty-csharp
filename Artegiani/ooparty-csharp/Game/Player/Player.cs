namespace ooparty_csharp.Game.Player
{
    /// <summary>
    /// Implementation of <see cref="IPlayer"/>.
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// Builds a <see cref="Player"/>.
        /// </summary>
        /// <param name="nickname">The nickname of the player.</param>
        public Player(string nickname)
        {
            Nickname = nickname;
        }

        public string Nickname { get; private set; }
    }
}