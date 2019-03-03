namespace Mallos.Serialization
{
    public interface ISerializable
    {
        void GetObjectData(SerializationStream stream);
    }
}
