using System;
using System.Collections.Generic;
using System.Text;

namespace Mao.ClientInformationSystem.Core.Models.Response
{
    public class AddIntResponseModel
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? EmpId { get; set; }
        public DateTime? IntDate { get; set; }
        public string Remarks { get; set; }
        public char? IntType { get; set; }

    }
}
