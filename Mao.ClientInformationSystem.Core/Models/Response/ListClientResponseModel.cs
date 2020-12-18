using System;
using System.Collections.Generic;
using System.Text;

namespace Mao.ClientInformationSystem.Core.Models.Response
{
    public class ListClientResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phones { get; set; }
        public string Address { get; set; }
        public DateTime? AddedOn { get; set; }
    }
}
