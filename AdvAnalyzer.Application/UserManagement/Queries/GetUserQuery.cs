using AdvAnalyzer.Application.UserManagement.DTOs;
using AdvAnalyzer.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAnalyzer.Application.UserManagement.Queries
{
    public class GetUserQuery : IQuery<UserDto>
    {
        public GetUserQuery(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }
    }
}
