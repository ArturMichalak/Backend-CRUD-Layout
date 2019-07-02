using backend.Entities;
using backend.Interfaces;
using System;

namespace backend.Common
{
    public class WorkingTime : ICommand<WorkingTimeLog>
    {

        public WorkingTimeLog Run()
        {
            throw new NotImplementedException();
        }

        public WorkingTime(IRepository<WorkingTimeLog> workingTimeLog) => _workingTimeLog = workingTimeLog;
        private readonly IRepository<WorkingTimeLog> _workingTimeLog;
    }
}
