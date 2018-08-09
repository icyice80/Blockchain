using System.Collections.Generic;

namespace Domain
{
    public class Blockchain
    {

        public Blockchain()
        {
            this.Blocks = new List<Block> { BlockUtil.GenesisBlock };
        }

        public IList<Block> Blocks { get; private set; }

        public Block AddBlock(object data) {

            var newBlock = BlockUtil.MineBlock(this.Blocks[this.Blocks.Count - 1], data);

            this.Blocks.Add(newBlock);

            return newBlock;
        }


        public bool ReplaceChain(Blockchain chain) {

            if (chain.Blocks.Count <= this.Blocks.Count) {
                //TODO: log the given chain and indicate the given chain is invalid.
                return false;
            }

            if (!BlockchainUtil.IsValid(chain)) {
                //TODO: log the given chain and indicate the given chain is invalid.
                return false;
            }

            this.Blocks = chain.Blocks;

            return true;

        }
    }
}
