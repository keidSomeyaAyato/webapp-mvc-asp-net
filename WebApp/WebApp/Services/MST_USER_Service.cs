using System;
using System.Diagnostics;
using System.Linq;
using WebApp.Models;

namespace WebApp.Services
{
    public class MST_USERService
    {
        private readonly MST_USERDBContext _dbContext;

        public MST_USERService()
        {
            _dbContext = new MST_USERDBContext();
        }

        public bool Login(string loginUserID, string loginPassword, string userIPAddress)
        {
            try
            {
                // ユーザーが存在するかを確認
                var user = _dbContext.USER.FirstOrDefault(u => u.USER_CD == loginUserID.Trim() && u.PASSWORD == loginPassword.Trim());

                if (user != null)
                {
                    // LAST_LOGIN_TIMEとUSER_IP_ADDRを更新
                    user.LAST_LOGIN_TIME = DateTime.Now;
                    user.USER_IP_ADDR = userIPAddress;

                    // データベースに変更を保存
                    _dbContext.SaveChanges();

                    return true; // ログイン成功
                }

                return false; // ユーザーが見つからない、またはパスワードが不一致
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                return false;
            }
        }

        public void MST_USERCheck()
        {
            try
            {
                Debug.WriteLine("MST_USER テーブルのデータチェックを開始します。");

                var allUsers = _dbContext.USER.ToList();
                Debug.WriteLine($"データベース内のユーザー数: {allUsers.Count}");

                foreach (var user in allUsers)
                {
                    Debug.WriteLine($"USER_CD: {user.USER_CD}, USER_NM: {user.USER_NM}, PASSWORD: {user.PASSWORD}, LAST_LOGIN_TIME: {user.LAST_LOGIN_TIME}, LAST_LOGOUT_TIME: {user.LAST_LOGOUT_TIME}, USER_IP_ADDR: {user.USER_IP_ADDR}");
                }

                Debug.WriteLine("MST_USER テーブルのデータチェックが完了しました。");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during MST_USERCheck: {ex.Message}");
            }
        }
    }
}
