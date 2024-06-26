﻿using DemoMediatR.Domain.Entities;

namespace MediatR.Application.Queries;

public sealed class GetPersonsQuery : IRequest<IEnumerable<Person>> { }
