using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using Microsoft.SqlServer.Server;


[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.UserDefined, IsFixedLength = false, MaxByteSize = 8000)]
public struct LevelUDT : INullable, IBinarySerialize
 {
    public override string ToString() {
        // Replace with your own code
        return string.Empty;
    }

    public bool IsNull {
        get {
            // Put your code here
            return _null;
        }
    }

    public static LevelUDT Null {
        get {
            LevelUDT h = new LevelUDT();
            h._null = true;
            return h;
        }
    }

    public static LevelUDT Parse(SqlString s) {
        if (s.IsNull)
            return Null;
        LevelUDT u = new LevelUDT();
        // Put your code here
        return u;
    }

    // This is a place-holder member field
    public string Name;

    //  Private member
    private bool _null;
    public void Write(BinaryWriter w) {
        w.Write(Name);
    }

    public void Read(BinaryReader r) {
        Name = r.ReadString();
    }

}