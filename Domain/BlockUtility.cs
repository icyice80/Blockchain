using System;
using System.Collections.Generic;
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


        public static Block MineBlock(Block lastBlock, object data)
        {
            var createdTime = DateTime.Now;
            var hash = Hash(createdTime, lastBlock.Hash, data);
            return new Block(DateTime.Now, lastBlock.Hash, hash, data);
        }
        
        #endregion


        private static Block GenerateGenesisBlock() {

            return new Block(new DateTime(2009, 1, 1), "------------", "abcd-efgh-ijkl", new { Name = "this is the genesis block" });
        }


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
