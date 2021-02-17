using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_1.Core
{
    public class UsersCore :FullAuditedEntity
    {
        public string UsersQuestion { get; set; }
        public string Answer { get; set; }
    }
}
