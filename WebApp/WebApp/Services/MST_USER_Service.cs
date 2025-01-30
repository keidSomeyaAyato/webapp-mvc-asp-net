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

        public bool UserCheck(string LoginUserID)
        {
            try
            {
                // ユーザーが存在するかを確認
                var user = _dbContext.USER.FirstOrDefault(u => u.USER_CD == LoginUserID.Trim());

                if (user != null)
                {
                    return true; // ログイン成功
                }

                return false; // ユーザーが見つからない
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PasswordCheck(string LoginUserID,string LoginPassword)
        {
            try
            {
                var user = _dbContext.USER.FirstOrDefault(u => u.USER_CD == LoginUserID.Trim() && u.PASSWORD == LoginPassword.Trim());

                if (user != null)
                {
                    return true; //パスワード一致
                }

                return false; //パスワード不一致

            }
            catch(Exception)
            {
                return false;
            }
        }

        public void UpdateLastLoginTimeAndIp(string loginUserId, string ipAddress)
        {
            // ユーザーを取得
            var user = _dbContext.USER.FirstOrDefault(u => u.USER_CD == loginUserId.Trim());

            if (user != null)
            {
                // LAST_LOGIN_TIMEを現在時刻に更新
                user.LAST_LOGIN_TIME = DateTime.Now;

                // USER_IP_ADDRを引数で受け取ったIPアドレスに更新
                user.USER_IP_ADDR = ipAddress;

                // データベースを保存
                _dbContext.SaveChanges();
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

        public string GetName(string USER_CD)
        {
            // データベースから USER_CD に一致するユーザーを検索
            var user = _dbContext.USER.FirstOrDefault(u => u.USER_CD == USER_CD.Trim());

            // ユーザーが見つかった場合は USER_NM を返却、それ以外は null
            return user?.USER_NM;
        }

    }
}
