using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    [DataObject]
    public class Role {
    
        private static RoleTableAdapter roleTableAdapter = new RoleTableAdapter();

        private static RolesTableAdapter rolesTableAdapter = new RolesTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.RolesDataTable SelectRoles() {
            return rolesTableAdapter.GetData();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.RoleDataTable SelectRole(string roleName) {
            return roleTableAdapter.GetData(roleName);
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
