using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trening.Models;
using Trening.Utilities;

namespace Trening.Library
{
    public class LoginUtility
    {
        private TreningEntities db = new TreningEntities();

        public string Login(string username, string password)
        {
            //        db.Registration.Where
            var user = db.UserRegistration.Where(u => u.Email == username).FirstOrDefault<UserRegistration>();

            if (user != null)
            {
                if (user.Password == password)
                {
                    return CreateTokenString(username);
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public string CreateTokenString(string uid)
        {
            var guid = Guid.NewGuid();
            var ret = uid + ":" + guid.ToString();
            return Base64.Encode(ret);
        }
    }
}