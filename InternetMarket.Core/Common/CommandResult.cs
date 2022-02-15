using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.Core.Common
{
    public class CommandError
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public CommandError(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }
    public class CommandResult
    {
        public IList<CommandError> Errors { get; }

        public bool Failed => Errors.Any();

        public CommandResult()
        {
            Errors = new List<CommandError>();
        }
        public CommandResult(Exception e)
        {
            Errors.Add(new CommandError(-1, "System error"));
        }

        public void AddError(int errorCode, string errorMessage)
        {
            Errors.Add(new CommandError(errorCode, errorMessage));
        }
        public void AddError(CommandError error)
        {
            Errors.Add(error);
        }
    }

    public class CommandResult<T> : CommandResult
    {
        public T Value { get; set; }

        public CommandResult()
            : base()
        {

        }

        public CommandResult(Exception e)
            : base(e)
        {

        }
    }
}
