using GraphQL.Types;

namespace UserManagementAPI.Type
{
    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("nombre");
            Field<StringGraphType>("apellidoPaterno");
            Field<StringGraphType>("apellidoMaterno");
            Field<IntGraphType>("telefono");
            Field<StringGraphType>("direccion");
            Field<StringGraphType>("email");

        }
    }
}
