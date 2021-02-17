using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_1.AppServices.UserInputAppService.DTOs
{
    public class QuestionsOutput
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime DateTime { get; set; }

    }
}
