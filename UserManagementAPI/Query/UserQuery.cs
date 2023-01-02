using GraphQL;
using GraphQL.Types;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Type;

namespace UserManagementAPI.Query
{
    public class UserQuery : ObjectGraphType
    {
        public UserQuery(IUser userService)
        {
            Field<ListGraphType<UserType>>("users", resolve: context =>
            {
                return userService.GetAllUsers();
            });

            Field<UserType>("user", arguments: new QueryArguments(new QueryArgument<IntGraphType>
            {
                Name = "id"
            }),
            resolve: context =>
            {
                return userService.GetUserById(context.GetArgument<int>("id"));
            });
        }
    }
}
