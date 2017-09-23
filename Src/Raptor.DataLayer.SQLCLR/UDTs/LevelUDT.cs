using System;
using System.Data.SqlTypes;
using System.IO;

using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.UserDefined, IsFixedLength = false, MaxByteSize = 8000)]
public struct LevelUDT : INullable, IBinarySerialize
 {
    public override string ToString() => string.Empty;

    public bool IsNull => _null;

    public static LevelUDT Null => new LevelUDT { _null = true };

     public static LevelUDT Parse(SqlString s)
    {
        return s.IsNull ? Null : new LevelUDT();
    }
    
    public string Name;
    
    private bool _null;

    public void Write(BinaryWriter w) {
        w.Write(Name);
    }

    public void Read(BinaryReader r) {
        Name = r.ReadString();
    }

}