using System;
using System.Security.Cryptography;
using System.Text;

public class Block{
    public int Index { get; set; }
    public DateTime TimeStamp { get; set; }
    public string PreviousHash { get; set; }
    public string Hash { get; set; }
    public string Data { get; set; }
    public int Nonce { get; set; }

    public Block(int index, DateTime timeStamp, string previousHash, string data){
        Index = index;
        TimeStamp = timeStamp;
        PreviousHash = previousHash;
        Data = data;
        Hash = CreateHash();
    }

    public string CreateHash(){
        using (SHA256 sha256 = SHA256.Create()){
            string rawData = $"{Index}-{TimeStamp}-{PreviousHash ?? ""}-{Data}";
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return BitConverter.ToString(bytes).Replace("-", "");
        }
    }
}