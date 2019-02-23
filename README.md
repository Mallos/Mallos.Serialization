# Mallos.Serialization
Simplify binary and non-binary serialization.

## Sample

```csharp
class Person : ISerializable
{
    public readonly string Name;

    public Person(string name)
    {
        this.Name = name;
    }

    public Person(SerializationInfo info, StreamingContext context)
    {
        this.Name = info.GetString("Name");
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Name", Name);
    }
}

var serializer = new Serializer();

var homerExport = new Person("Homer Simpson");
serializer.Serialize("./homer.dat", homerExport);

var homerImport = serializer.Deserialize<Person>("./homer.dat");
```

## License
The project is available as open source under the terms of the [MIT License](http://opensource.org/licenses/MIT).
