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

    #region Get Withdraw By PhoneNumber Async

    public async Task<List<WithdrawModel>> GetWithdrawByPhoneNumberAsync(string phoneNumber)
    {
        string query = "SELECT * FROM Tbl_Withdraw WHERE PhoneNumber = @PhoneNumber AND DeleteFlag = 0;";
        var result = await _dapperService.QueryAsync<WithdrawModel>(query, new { PhoneNumber = phoneNumber });
        return result.ToList(); 
    }

    #endregion

    #region Get User By PhoneNumber

    public async Task<UserModel?> GetUserByPhoneNumberAsync(string phoneNumber)
    {
        string query = "SELECT * FROM Tbl_User WHERE PhoneNumber = @PhoneNumber AND DeleteFlag = 0;";
        return await _dapperService.QueryFirstOrDefaultAsync<UserModel>(query, new { PhoneNumber = phoneNumber });
    }

    #endregion

    #region Update User Balance

    public async Task<int> UpdateUserBalanceAsync(string phoneNumber, decimal updatedBalance)
    {
        string query = "UPDATE Tbl_User SET Balance = @UpdatedBalance WHERE PhoneNumber = @PhoneNumber AND DeleteFlag = 0;";
        return await _dapperService.ExecuteAsync(query, new { UpdatedBalance = updatedBalance, PhoneNumber = phoneNumber });
    }

    #endregion



}
