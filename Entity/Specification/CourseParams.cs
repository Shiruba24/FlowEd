﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Specification
{
    public class CourseParams
    {
        public string? Sort { get; set; } = string.Empty;
        public int? CategoryId { get; set; }
        public int PageIndex { get; set; } = 1;
        private const int MaxPageSize = 20;
        private int _pageSize = 3;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}
