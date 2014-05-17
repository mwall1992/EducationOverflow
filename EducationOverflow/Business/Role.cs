using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    public class Role {
    
        private static RoleTableAdapter roleTableAdapter = new RoleTableAdapter();

        private static RolesTableAdapter rolesTableAdapter = new RolesTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<DataObjects.Role> SelectRoles() {
            List<DataObjects.Role> roles = new List<DataObjects.Role>();
            DataAccess.EducationOverflow.RolesDataTable rolesDataTable = rolesTableAdapter.GetData();

            foreach (DataAccess.EducationOverflow.RolesRow row in rolesDataTable.Rows) {
                roles.Add(new DataObjects.Role() {
                    Name = row.Name,
                    Description = row.Description
                });
            }

            return roles;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataObjects.Role SelectRole(string roleName) {
            DataAccess.EducationOverflow.RoleDataTable roleDataTable = roleTableAdapter.GetData(roleName);

            DataObjects.Role role = null;
            if (roleDataTable.Count > 0) {

                DataAccess.EducationOverflow.RoleRow roleRow = 
                    (DataAccess.EducationOverflow.RoleRow)roleDataTable.Rows[0];

                role = new DataObjects.Role() {
                    Name = roleRow.Name,
                    Description = roleRow.Name
                };
            }

            return role;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertRole(string roleName, string description) {
            return roleTableAdapter.Insert(roleName, description);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateRole(string roleName, string description, string originalRoleName) {
            return roleTableAdapter.Update(roleName, description, originalRoleName);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteRole(string originalRoleName) {
            return roleTableAdapter.Delete(originalRoleName);
        }
    
    }
}
