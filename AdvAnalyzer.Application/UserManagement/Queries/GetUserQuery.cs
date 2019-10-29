using AdvAnalyzer.Application.UserManagement.DTOs;
using AdvAnalyzer.Common.Types;

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
