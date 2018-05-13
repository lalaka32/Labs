namespace OOP_3
{
    interface INameAndCopy
    {
        string Name
        { get; set; }
        object DeepCopy();
    }
}
