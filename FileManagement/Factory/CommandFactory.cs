using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement
{
    public interface ICommandFactory
    {
        ICommand Create(SyncInfo info);
        List<ICommand> GetCommands();
    }
}
