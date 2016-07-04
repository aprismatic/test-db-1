using System.Data.SqlTypes;
using PaillierExt.Homomorphism;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBinary PaillierAddition(SqlBinary left, SqlBinary right, SqlBinary N)
    {
        return new SqlBinary(PaillierHomomorphism.Addition(left.Value, right.Value, N.Value));
    }
}
