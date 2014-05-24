using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing CRUD operations on data associated with user roles.
    /// </summary>
    /// <remarks>
    /// This class is commonly used by the custom role provider class for managing role information.
    /// </remarks>
    [DataObject]
    public class Role {

        /// <summary>
        /// The table adapter used for individual role information.
        /// </summary>
        private static RoleTableAdapter roleTableAdapter = new RoleTableAdapter();

        /// <summary>
        /// The table adapter used for information on roles.
        /// </summary>
        private static RolesTableAdapter rolesTableAdapter = new RolesTableAdapter();

        /// <summary>
        /// Retrieve all the roles.
        /// </summary>
        /// <returns>A table containing information on all roles.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.RolesDataTable SelectRoles() {
            return rolesTableAdapter.GetData();
        }

        /// <summary>
        /// Retrieve information of a specific role name.
        /// </summary>
        /// <param name="roleName">The name of the role.</param>
        /// <returns>A table containing information on all roles with the specified name.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.RoleDataTable SelectRole(string roleName) {
            return roleTableAdapter.GetData(roleName);
        }

        /// <summary>
        /// Insert a role.
        /// </summary>
        /// <param name="roleName">The name of the role.</param>
        /// <param name="description">The description of the role.</param>
        /// <returns>The number of rows affected by the insertion.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertRole(string roleName, string description) {
            return roleTableAdapter.Insert(roleName, description);
        }

        /// <summary>
        /// Update a role.
        /// </summary>
        /// <param name="roleName">The name of the role.</param>
        /// <param name="description">The description of the role.</param>
        /// <param name="originalRoleName">The original name of the role.</param>
        /// <returns>The number of rows affected by the update.</returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateRole(string roleName, string description, string originalRoleName) {
            return roleTableAdapter.Update(roleName, description, originalRoleName);
        }

        /// <summary>
        /// Delete a role.
        /// </summary>
        /// <param name="originalRoleName">The original name of the role.</param>
        /// <returns>The number of rows affected by the deletion.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteRole(string originalRoleName) {
            return roleTableAdapter.Delete(originalRoleName);
        }
    }
}
