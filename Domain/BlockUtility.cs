using System;
using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace Domain
{
    public class BlockUtil
    {
        private readonly static Lazy<Block> genesisBlock = new Lazy<Block>(GenerateGenesisBlock);

        #region properties
        public static Block GenesisBlock { get; } = genesisBlock.Value;

        #endregion

        #region public methods

        /// <summary>
        /// produce a new block based on the given input
        /// </summary>
        /// <param name="lastBlock"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Block MineBlock(Block lastBlock, object data)
        {
            var createdTime = DateTime.Now;
            var hash = Hash(createdTime, lastBlock.Hash, data);
            return new Block(DateTime.Now, lastBlock.Hash, hash, data);
        }

        /// <summary>
        /// generate a hash value for a given block.
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        public static string GenerateHash(Block block) {
            return Hash(block.CreatedTime, block.PreviousHash, block.Data);
        }

        #endregion


        /// <summary>
        /// generate genesis block.
        /// </summary>
        /// <returns></returns>
        private static Block GenerateGenesisBlock() {

            return new Block(new DateTime(2009, 1, 1), "------------", "abcd-efgh-ijkl", new { Name = "this is the genesis block" });
        }

        /// <summary>
        /// generate a hash based given values.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="lastHash"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private static string Hash(DateTime dateTime, string lastHash, object data)
        {
            byte[] hash = null;
            using (var algorithm = SHA256.Create())
            {
                var valueToBeHashed = $"{dateTime.ToTimestamp()}{lastHash}{JsonConvert.SerializeObject(data)}";
                hash = algorithm.ComputeHash(Encoding.ASCII.GetBytes(valueToBeHashed));
            }

            return Encoding.Default.GetString(hash);
        }

    }
}
