﻿using Application.Common.Parameters;

namespace Application.Features.Products.Queries
{
    public class PaginationProductParameters : RequestParameters
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public double? Rating { get; set; }
    }
}
