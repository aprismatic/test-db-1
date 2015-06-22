using System.Data.SqlTypes;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBinary PaillierAddition(SqlBinary left, SqlBinary right, SqlBinary N)
    {
        var bi_left = new BigInteger(left.Value);
        var bi_right = new BigInteger(right.Value);
        var bi_N = new BigInteger(N.Value);

        var bi_res = (bi_left * bi_right) % (bi_N * bi_N);

        return new SqlBinary(bi_res.getBytes());
    }
}
