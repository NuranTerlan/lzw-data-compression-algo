namespace LZWAlgorithm
{
    public interface IOperations
    {
        string Data { get; set; }
        string Encode();
        string Decode();
    }
}