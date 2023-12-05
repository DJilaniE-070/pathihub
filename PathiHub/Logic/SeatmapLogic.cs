public static class SeatmapLogic
{
    public static bool CheckCurrentUser()
    {
        AccountModel user = AccountsLogic.CurrentAccount;
        if (user!= null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}