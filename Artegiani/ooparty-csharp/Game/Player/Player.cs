using System;

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

        public override bool Equals(object obj)
        {
            return Equals(obj as Player);
        }

        private bool Equals(Player other)
        {
            return other != null && GetHashCode().Equals(other.GetHashCode());
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nickname);
        }
    }
}