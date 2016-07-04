using ElGamalExt.Homomorphism;
using System.Data.SqlTypes;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBinary ElGamalMultiplication(SqlBinary left, SqlBinary right, SqlBinary P)
    {
        return new SqlBinary(ElGamalHomomorphism.Multiply(left.Value, right.Value, P.Value));
    }
}
