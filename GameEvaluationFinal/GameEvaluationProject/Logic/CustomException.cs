using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Exceptions
{
    public enum ErrorCode
    {
        InvalidUsername,
        InvalidEmail,
        InvalidPassword,
        GameSavingError,
        GameRetrievalError,
        GameDeletionError,
        UserRetrievalError,
        UserSavingError,
        ReviewRetrievalError,
        ReviewSavingError,
        GameIdRetrievalError,
        GeneralError,
        InvalidCredentials,
    }
    public class CustomException : Exception
    {


        public ErrorCode Code { get; private set; }

        public CustomException(ErrorCode code) : base(code.ToString())
        {
            Code = code;
        }

        public CustomException(ErrorCode code, Exception inner) : base(code.ToString(), inner)
        {
            Code = code;
        }
    }
}
