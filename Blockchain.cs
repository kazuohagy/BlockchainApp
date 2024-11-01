using System.Collections.Generic;
using System.Linq;

public class Blockchain{
    
    public IList<Block> Chain { get; set;} = new List<Block>();

    public Blockchain(){
        InitializeChain();
        AddGenesisBlock();
    }

    private void InitializeChain(){
        Chain = new List<Block>();
    }

    private void AddGenesisBlock(){
        Chain.Add(new Block(0, DateTime.Now, "0", "Genesis Block"));
    }

}