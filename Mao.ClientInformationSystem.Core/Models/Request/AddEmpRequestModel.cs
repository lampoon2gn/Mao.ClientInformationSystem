using System;
using System.Collections.Generic;
using System.Text;

namespace Mao.ClientInformationSystem.Core.Models.Request
{
    public class AddEmpRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Designation { get; set; }
    }
}
