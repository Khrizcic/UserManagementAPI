using UserManagementAPI.Mutation;
using UserManagementAPI.Query;

namespace UserManagementAPI.Schema
{
    public class UserSchema : GraphQL.Types.Schema
    {
        public UserSchema(UserQuery userQuery, UserMutation userMutation)
        {
            Query = userQuery;
            Mutation = userMutation;
        }
    }
}
