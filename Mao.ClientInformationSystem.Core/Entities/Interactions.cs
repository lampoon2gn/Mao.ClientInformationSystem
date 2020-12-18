﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mao.ClientInformationSystem.Core.Entities
{
    public class Interactions
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public Clients Clients { get; set; }
        public int? EmpId { get; set; }
        public Employees Employees { get; set; }
        public char? IntType { get; set; }
        public DateTime? IntDate { get; set; }
        public string Remarks { get; set; }
    }
}
