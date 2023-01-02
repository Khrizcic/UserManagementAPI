using GraphQL;
using GraphQL.Types;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;
using UserManagementAPI.Type;

namespace UserManagementAPI.Mutation
{
    public class UserMutation : ObjectGraphType
    {
        public UserMutation(IUser userService)
        {
            Field<UserType>("createUser", arguments: new QueryArguments(new QueryArgument<UserInputType>
            {
                Name = "user"
            }), resolve: context =>
            {
                return userService.AddUser(context.GetArgument<User>("user"));
            });

            Field<UserType>("updateUser", arguments: new QueryArguments(new QueryArgument<IntGraphType>
            {
                Name = "id"
            }, new QueryArgument<UserInputType>
            {
                Name = "user"
            }), resolve: context =>
            {
                var userObj = context.GetArgument<User>("user");
                var userId = context.GetArgument<int>("id");
                return userService.UpdateUser(userId, userObj);
            });

            Field<StringGraphType>("deleteUser", arguments: new QueryArguments(new QueryArgument<IntGraphType>
            {
                Name = "id"
            }), resolve: context =>
            {
                var userId = context.GetArgument<int>("id");
                userService.DeleteUser(userId);
                return "User with id: " + userId + " was successfully removed";
            });
        }
    }
}
