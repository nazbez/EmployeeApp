﻿using System.Diagnostics.CodeAnalysis;

namespace EmployeeApp.Backend.API.Infrastructure.Models;

[ExcludeFromCodeCoverage]
public class EmployeeGetAllRequestModel
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
