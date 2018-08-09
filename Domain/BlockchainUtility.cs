namespace Domain
{
    public class BlockchainUtil
    {
        /// <summary>
        /// check the given chain is valid. 
        /// </summary>
        /// <param name="blockchain"></param>
        /// <returns></returns>

        public static bool IsValid(Blockchain blockchain) {

            if (blockchain == null) {

                return false;
            }

            var blocks = blockchain.Blocks;

            if (blocks.Count < 1) {
                return false;
            }

            if (blocks[0].ToString() != BlockUtil.GenesisBlock.ToString()) {

                return false;
            }

            for (var i = 0; i < blocks.Count; i++) {
                var block = blocks[i];
                var lastblock = blocks[i - 1];

                if (block.PreviousHash != lastblock.Hash || block.Hash != BlockUtil.GenerateHash(block)) {
                    return false;
                }
            }

            return true;
        }
    }
}
