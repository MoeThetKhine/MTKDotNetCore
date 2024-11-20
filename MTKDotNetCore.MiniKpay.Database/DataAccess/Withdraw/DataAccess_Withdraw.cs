using MTKDotNetCore.MiniKpay.Database.Models.Withdraw;

namespace MTKDotNetCore.MiniKpay.Database.DataAccess.Withdraw;

public class DataAccess_Withdraw
{
    private readonly DapperService _dapperService;

    public DataAccess_Withdraw(DapperService dapperService)
    {
        _dapperService = dapperService;
    }

    #region GetWithdrawListAsync

    public async Task<List<WithdrawModel>> GetWithdrawListAsync()
    {
        string query = "SELECT * FROM Tbl_Withdraw WHERE DeleteFlag =0;";
        var result = await _dapperService.QueryAsync<WithdrawModel>(query); 
        return result.ToList();
    }

    #endregion


}
