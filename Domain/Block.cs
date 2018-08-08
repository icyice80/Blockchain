using System;
using Newtonsoft.Json;

namespace Domain
{
    /// <summary>
    /// Block class 
    /// </summary>
    public class Block
    {
        public Block(DateTime datetime, string lastHash, string hash, object data)
        {
            CreatedTime = datetime;
            PreviousHash = lastHash;
            Hash = hash;
            Data = data;
        }

        public DateTime CreatedTime { get; }

        public string PreviousHash { get; }

        public string Hash { get; }

        public object Data { get; }


        public override string ToString()
        {
            return $"Block - " +
                $"{Environment.NewLine}Timestamp: {CreatedTime.ToTimestamp()} " +
                $"{Environment.NewLine}Previous Hash: {PreviousHash} " +
                $"{Environment.NewLine}Hash: {Hash} " +
                $"{Environment.NewLine}Data: {GetSerializedData()}";
        }


        private string GetSerializedData() {
            return JsonConvert.SerializeObject(Data);
        }
    }
}
