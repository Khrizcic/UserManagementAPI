using GraphQL.Language.AST;
using GraphQL.Types;
using UserManagementAPI.Models;

namespace UserManagementAPI.Type
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(u => u.Id);
            Field(u => u.Nombre);
            Field(u => u.ApellidoPaterno);
            Field(u => u.ApellidoMaterno);
            Field(u => u.Telefono);
            Field(u => u.Direccion);
            Field(u => u.Email);
        }
    }
}
